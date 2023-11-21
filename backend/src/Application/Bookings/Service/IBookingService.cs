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
    public Task<IEnumerable<BookingDTO>?> GetAllBookings();
    public Task<BookingDTO?> GetBooking(int id);
    public Task<Result> AddBooking(BookingDTO booking);
    public Task<Result> UpdateBooking(BookingDTO booking);
    public Task<Result> DeleteBooking(int id);
}
