using backend.Application.Bookings.DTOs;
using backend.Application.Common.Models;
using MediatR;

namespace backend.Application.Bookings.Commands.UpdateBooking;
public record UpdateBookingCommand(BookingDTO Booking) : IRequest<Result>;
