using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.Application.Bookings.DTOs;
using backend.Application.Common.Models;
using backend.Domain.Entities;
using MediatR;

namespace backend.Application.Bookings.Commands.UpdateBooking;
public record UpdateBookingCommand(BookingDTO Booking) : IRequest<Result>;
