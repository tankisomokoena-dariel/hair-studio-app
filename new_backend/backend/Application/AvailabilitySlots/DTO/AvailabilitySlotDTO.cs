using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AvailabilitySlots.DTO
{
    public record AvailabilitySlotDTO
    {
        public Guid Id { get; init; }
        public Guid BookingId { get; init; }
        public DateTime Date { get; init; }
        public DateTime StartTime { get; init; }
        public DateTime EndTime { get; init; }
    }
}
