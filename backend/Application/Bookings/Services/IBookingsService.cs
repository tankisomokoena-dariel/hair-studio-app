using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Services;
using backend.Application.Bookings.DTOs;
using backend.Application.Common.Models;
using backend.Domain.Entities;

namespace backend.Application.Bookings.Service;
public interface IBookingsService : IGenericService<BookingDTO>
{
}
