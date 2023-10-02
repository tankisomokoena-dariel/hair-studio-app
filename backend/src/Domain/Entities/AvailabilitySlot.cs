using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.Domain.Entities;
public class AvailabilitySlot : BaseAuditableEntity
{
    public DateOnly Date {  get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set;}
}
