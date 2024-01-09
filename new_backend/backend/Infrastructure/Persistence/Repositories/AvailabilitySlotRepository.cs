using backend.Application.Common.Interfaces.Repositories;
using backend.Domain.Entities;
using Infrastructure.Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class AvailabilitySlotRepository : GenericRepository<AvailabilitySlot>, IAvailabilitySlotRepository
    {
        public AvailabilitySlotRepository(HairStudioDbContext dbContext) : base(dbContext)
        {
        }
    }
}
