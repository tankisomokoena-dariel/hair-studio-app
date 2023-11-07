using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.Application.Common.Mappings;
using backend.Domain.Entities;

namespace backend.Application.Bookings.DTOs;
public record BookingDTO : IMapFrom<Booking>
{
    public int Id { get; init; }
    public int UserId { get; init; }
    public int ServiceId { get; init; }
    public DateTime Date { get; init; }
    public DateTime StartTime { get; init; }
    public DateTime EndTime { get; init; }
    public string? Comments { get; init; }
}

