using backend.Application.Bookings.Commands.CreateBooking;
using backend.Application.Bookings.Commands.DeleteBooking;
using backend.Application.Bookings.Commands.UpdateBooking;
using backend.Application.Bookings.DTOs;
using backend.Application.Bookings.Queries;
using backend.Application.Common.Models;
using backend.Domain.Entities;
using MediatR;
using System.Net.Http.Headers;

namespace backend.Application.Bookings.Service;
public class BookingsService : IBookingsService
{
    private readonly IMediator _mediator;
    public BookingsService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<Result> AddAsync(BookingDTO item)
    {
        return await _mediator.Send(new CreateBookingCommand(item));
    }

    public async Task<Result> DeleteAsync(Guid id)
    {
        return await _mediator.Send(new DeleteBookingCommand(id));
    }

    public async Task<IEnumerable<BookingDTO>?> GetAsync()
    {
        return await _mediator.Send(new GetAllBookingsQuery());
    }

    public async Task<BookingDTO?> GetByIdAsync(Guid id)
    {
        return await _mediator.Send(new GetBookingQuery(id));
    }

    public async Task<Result> UpdateAsync(BookingDTO item)
    {
        return await _mediator.Send(new UpdateBookingCommand(item));
    }
}
