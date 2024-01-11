using backend.Domain.Entities;
using backend.Infrastructure.Persistence.Interceptors;
using Domain.Common;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.DatabaseContext
{
    public class HairStudioDbContext : DbContext, IHairStudioDbContext
    {
        private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChanges;

        public HairStudioDbContext(DbContextOptions<HairStudioDbContext> options,
            AuditableEntitySaveChangesInterceptor auditableEntitySaveChanges) : base(options)
        {
            _auditableEntitySaveChanges = auditableEntitySaveChanges;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_auditableEntitySaveChanges);
        }

        public DbSet<AvailabilitySlot> AvailabilitySlots => Set<AvailabilitySlot>();
        public DbSet<Booking> Bookings => Set<Booking>();

    }
}
