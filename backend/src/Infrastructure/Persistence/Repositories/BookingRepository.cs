using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.Application.Common.Interfaces.Repositories;
using backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Infrastructure.Persistence.Repositories;
public class BookingRepository : IBookingRepository
{
    private readonly ApplicationDbContext _context;

    public BookingRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(Booking item)
    {
        await _context.Bookings.AddAsync(item);
        await _context.SaveChangesAsync();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Booking>?> GetAllAsync()
    {
        var result = await _context.Bookings.ToListAsync();
        return result;
    }

    public async Task<Booking?> GetByIdAsync(int id)
    {
        return await _context.Bookings.FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task UpdateAsync(Booking item)
    {
        throw new NotImplementedException();
    }
}
