using backend.Application.Bookings.DTOs;
using backend.Application.Common.Models;
using MediatR;

namespace backend.Application.Bookings.Commands.CreateBooking;
public record CreateBookingCommand(BookingDTO Booking) : IRequest<Result>;

