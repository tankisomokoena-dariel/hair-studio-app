using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.Application.Common.Interfaces.Repositories;
using backend.Domain.Entities;
using backend.Domain.Events;
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

    public async Task DeleteAsync(int id)
    {
        var booking = await _context.Bookings.FindAsync(id);

        if (booking == null)
        {
            return;
        }

        _context.Bookings.Remove(booking);
        _context.SaveChanges();
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

    public async Task UpdateAsync(Booking item)
    {
        var booking = await _context.Bookings.FindAsync(new object[] { item.Id });

        if (booking == null)
        {
            return;
        }

        booking.ServiceId = item.ServiceId;
        booking.Status = item.Status;
        booking.StartTime = item.StartTime;
        booking.EndTime = item.EndTime;
        booking.LastModified = item.LastModified;
        booking.LastModifiedBy = item.LastModifiedBy;
        booking.Comments = item.Comments;

        _context.SaveChanges();

    }
}
