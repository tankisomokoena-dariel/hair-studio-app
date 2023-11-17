using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.Application.Bookings.Commands.CreateBooking;
using backend.Application.Bookings.Commands.DeleteBooking;
using backend.Application.Bookings.Commands.UpdateBooking;
using backend.Application.Bookings.DTOs;
using backend.Application.Bookings.Queries;
using backend.Application.Common.Interfaces.Repositories;
using backend.Application.Common.Models;
using backend.Domain.Entities;
using backend.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace backend.Application.Bookings.Service;
public sealed class BookingService : IBookingService
{
    private readonly IMediator _mediator;
    public BookingService(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<Result> AddBookingAsync(BookingDTO booking)
    {
        return await _mediator.Send(new CreateBookingCommand(booking));     
    }

    public async Task<Result> DeleteBookingAsync(int id)
    {
        return await _mediator.Send(new DeleteBookingCommand(id));
    }

    public async Task<IEnumerable<BookingDTO>?> GetAllBookingsAsync()
    {
        return await _mediator.Send(new GetAllBookingsQuery());
    }

    public async Task<BookingDTO?> GetBookingAsync(int id)
    {
        return await _mediator.Send(new GetBookingQuery(id));
    }

    public async Task<Result> UpdateBookingAsync(BookingDTO booking)
    {
        return await _mediator.Send(new UpdateBookingCommand(booking));
    }
}
