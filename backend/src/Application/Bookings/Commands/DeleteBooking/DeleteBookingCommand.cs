using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.Application.Common.Models;
using MediatR;

namespace backend.Application.Bookings.Commands.DeleteBooking;
public record DeleteBookingCommand(int Id) : IRequest<Result>;
