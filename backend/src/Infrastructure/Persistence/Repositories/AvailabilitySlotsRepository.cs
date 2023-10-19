using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.Domain.Entities;
using backend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Infrastructure.Persistence.Repositories;
public sealed class AvailabilitySlotsRepository : IAvailabilitySlotRepository
{
    private readonly ApplicationDbContext _context;

    public AvailabilitySlotsRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public DbSet<AvailabilitySlot> AvailableSlots => throw new NotImplementedException();

    public async Task AddAsync(AvailabilitySlot item)
    {
       await _context.AvailabilitySlots.AddAsync(item);
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<AvailabilitySlot>?> GetAllAsync()
    {
        return await _context.AvailabilitySlots.ToListAsync();
    }

    public async Task<AvailabilitySlot?> GetByIdAsync(int id)
    {
        return await _context.AvailabilitySlots.FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task UpdateAsync(AvailabilitySlot item)
    {
        throw new NotImplementedException();
    }
}
