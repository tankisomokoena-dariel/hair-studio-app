using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.Domain.Entities;
public class Customer : BaseAuditableEntity
{
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public string? Email { get; set; }
    public required string PhoneNumber { get; set; }
    public DateOnly? DateOfBirth { get; set; }
}
