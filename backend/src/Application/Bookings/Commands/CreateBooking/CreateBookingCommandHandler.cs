using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.Application.Common.Interfaces.Repositories;
using backend.Application.Common.Models;
using backend.Domain.Entities;
using backend.Domain.Events;
using MediatR;

namespace backend.Application.Bookings.Commands.CreateBooking;
public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, Result>
{
    readonly IBookingRepository _bookingRepository;
    public CreateBookingCommandHandler(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }
    public async Task<Result> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var booking = new Booking
            {
                ServiceId = request.Booking.ServiceId,
                UserId = request.Booking.UserId,
                Date = request.Booking.Date,
                StartTime = request.Booking.StartTime,
                EndTime = request.Booking.EndTime,
                Created = request.Booking.Created,
                CreatedBy = request.Booking.CreatedBy,
                LastModified = request.Booking.LastModified,
                LastModifiedBy = request.Booking.LastModifiedBy
            };

            booking.AddDomainEvent(new BookingCreatedEvent(booking));

            await _bookingRepository.AddAsync(booking);

            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure(new List<string> { ex.Message });
        }
    }
}
