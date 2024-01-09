using backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Interfaces
{
    public interface IHairStudioDbContext
    {
        DbSet<AvailabilitySlot> AvailabilitySlots { get; }
    }
}
