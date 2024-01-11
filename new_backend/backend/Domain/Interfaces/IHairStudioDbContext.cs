using backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Interfaces
{
    public interface IHairStudioDbContext
    {
        public DbSet<AvailabilitySlot> AvailabilitySlots { get; }
        public DbSet<Booking> Bookings { get; }
    }
}
