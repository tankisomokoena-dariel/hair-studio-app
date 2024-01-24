using backend.Application.Bookings.DTOs;
using MediatR;

namespace backend.Application.Bookings.Queries;
public record GetAllBookingsQuery : IRequest<List<BookingDTO>>;