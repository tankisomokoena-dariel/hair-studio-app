using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.Domain.Entities;
public class Review : BaseAuditableEntity
{
    public int CustomerId { get; set; }
    public int ServiceId { get; set; }
    public int Rating { get; set; }
    public string? Comments { get; set; }
}
