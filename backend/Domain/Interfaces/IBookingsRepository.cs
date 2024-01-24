using backend.Application.Common.Interfaces.Repositories;
using backend.Domain.Entities;

namespace Domain.Interfaces
{
    public interface IBookingsRepository : IGenericRepository<Booking>
    {
    }
}
