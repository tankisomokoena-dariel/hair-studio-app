using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.Application.Common.Interfaces.Repositories;
using backend.Application.Common.Models;
using backend.Domain.Events;
using MediatR;

namespace backend.Application.Bookings.Commands.DeleteBooking;
public class DeleteBookingCommandHandler : IRequestHandler<DeleteBookingCommand, Result>
{
    private readonly IBookingRepository _bookingRepository;
    public DeleteBookingCommandHandler(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }

    public async Task<Result> Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
    {
        var booking = await _bookingRepository.GetByIdAsync(request.Id);

        if (booking == null)
        {
            return Result.Failure(new List<string>() { "Booking does not exist." });
        }

        await _bookingRepository.DeleteAsync(request.Id);
        booking.AddDomainEvent(new BookingDeletedEvent(booking));
        return Result.Success();
    }
}
