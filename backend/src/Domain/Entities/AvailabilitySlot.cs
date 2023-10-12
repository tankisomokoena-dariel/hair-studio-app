using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.Domain.Entities;
public class AvailabilitySlot : BaseAuditableEntity
{
    public DateTime Date {  get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set;}
}
