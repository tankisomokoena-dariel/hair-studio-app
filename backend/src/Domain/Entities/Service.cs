using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.Domain.Entities;
public class Service : BaseAuditableEntity
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string ImageURL { get; set; }
    public required double Price { get; set; }
}
