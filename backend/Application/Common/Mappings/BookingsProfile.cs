using backend.Application.Bookings.DTOs;
using backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Mappings
{
    internal class BookingsProfile : GenericProfile<Booking, BookingDTO>
    {
    }
}
