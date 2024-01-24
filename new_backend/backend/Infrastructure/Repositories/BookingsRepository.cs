using backend.Application.Common.Interfaces.Repositories;
using backend.Domain.Entities;
using Domain.Interfaces;
using Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class BookingsRepository : GenericRepository<Booking>, IBookingsRepository
    {
        public BookingsRepository(HairStudioDbContext dbContext) : base(dbContext)
        {
        }
    }
}
