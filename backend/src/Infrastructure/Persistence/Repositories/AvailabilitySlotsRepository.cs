using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.RateLimiting;
using System.Threading.Tasks;
using backend.Application.Common.Interfaces.Repositories;
using backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Infrastructure.Persistence.Repositories;
public sealed class AvailabilitySlotsRepository : IAvailabilitySlotRepository
{
    private readonly ApplicationDbContext _context;

    public AvailabilitySlotsRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(AvailabilitySlot item)
    {
        await _context.AvailabilitySlots.AddAsync(item);
        await _context.SaveChangesAsync();
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

    public async Task UpdateAsync(AvailabilitySlot item)
    {
        var slot = await _context.AvailabilitySlots.FindAsync(new object[] { item.Id });

        if (slot == null)
        {
            return;
        }

        slot = item;
        await _context.SaveChangesAsync();
    }
}