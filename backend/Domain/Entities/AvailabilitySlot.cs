using Domain.Common;

namespace backend.Domain.Entities;
public class AvailabilitySlot : BaseAuditableEntity
{
    public Guid BookingId { get; set; }
    public DateTime Date {  get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set;}
}
