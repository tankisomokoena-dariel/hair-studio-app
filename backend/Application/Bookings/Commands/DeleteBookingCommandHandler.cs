using backend.Application.Common.Models;
using Domain.Interfaces;
using MediatR;

namespace backend.Application.Bookings.Commands.DeleteBooking;
public class DeleteBookingCommandHandler : IRequestHandler<DeleteBookingCommand, Result>
{
    private readonly IBookingsRepository _bookingRepository;
    public DeleteBookingCommandHandler(IBookingsRepository bookingRepository)
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

        await _bookingRepository.DeleteAsync(booking);
        booking.AddDomainEvent(new BookingDeletedEvent(booking));
        return Result.Success();
    }
}
