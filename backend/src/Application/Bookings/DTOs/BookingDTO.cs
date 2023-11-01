using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.Application.Common.Mappings;
using backend.Domain.Entities;

namespace backend.Application.Bookings.DTOs;
public class BookingDTO : IMapFrom<Booking>
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ServiceId { get; set; }
    public DateTime Date { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string? Comments { get; set; }
}
