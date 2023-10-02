using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.Domain.Entities;
public class CustomerManagement : BaseAuditableEntity
{
    public int CustomerId { get; set; }
    public AccountStatus Status { get; set; }
    public string Comments { get; set; }
}
