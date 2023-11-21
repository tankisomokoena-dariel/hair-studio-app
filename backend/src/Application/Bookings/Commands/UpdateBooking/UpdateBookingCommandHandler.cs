﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.Application.Common.Interfaces.Repositories;
using backend.Application.Common.Models;
using backend.Domain.Events;
using MediatR;

namespace backend.Application.Bookings.Commands.UpdateBooking;
public class UpdateBookingCommandHandler : IRequestHandler<UpdateBookingCommand, Result>
{
    private readonly IBookingRepository _bookingRepository;

    public UpdateBookingCommandHandler(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }
    public async Task<Result> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var booking = await _bookingRepository.GetByIdAsync(request.Booking.Id);

            if(booking == null)
            {
                return Result.Failure(new List<string>() { "Booking does not exist." });
            }

            booking.ServiceId = request.Booking.ServiceId;
            booking.Date = request.Booking.Date;
            booking.StartTime = request.Booking.StartTime;
            booking.EndTime = request.Booking.EndTime;
            booking.Status = request.Booking.Status;
            booking.Comments = request.Booking.Comments;
            

            booking.AddDomainEvent(new BookingUpdatedEvent(booking));
            await _bookingRepository.UpdateAsync(booking);
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure(new List<string>() { ex.Message });
        }
    }
}
