using backend.Application.Common.Models;
using MediatR;

namespace backend.Application.Bookings.Commands.DeleteBooking;
public record DeleteBookingCommand(Guid Id) : IRequest<Result>;
