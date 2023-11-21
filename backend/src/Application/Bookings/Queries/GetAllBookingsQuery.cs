using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.Application.Bookings.DTOs;
using MediatR;

namespace backend.Application.Bookings.Queries;
public record GetAllBookingsQuery : IRequest<List<BookingDTO>>;