using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.Domain.Entities;
public class Booking : BaseAuditableEntity
{
    public int UsertId { get; set; }
    public int ServiceId { get; set; }
    public DateTime Date { get; set; }
    public DateTime TimeIn { get; set; }
    public DateTime TimeOut { get; set; }
    public string? Comments { get; set; }
}