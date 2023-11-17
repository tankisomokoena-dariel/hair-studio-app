using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.Application.Bookings.DTOs;
using backend.Application.Common.Models;
using backend.Domain.Entities;

namespace backend.Application.Bookings.Service;
public interface IBookingService
{
    public Task<IEnumerable<BookingDTO>?> GetAllBookingsAsync();
    public Task<BookingDTO?> GetBookingAsync(int id);
    public Task<Result> AddBookingAsync(BookingDTO booking);
    public Task<Result> UpdateBookingAsync(BookingDTO booking);
    public Task<Result> DeleteBookingAsync(int id);
}
