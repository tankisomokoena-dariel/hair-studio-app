using backend.Application.Bookings.DTOs;
using backend.Application.Bookings.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebUI.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class BookingsController : ControllerBase
{
    private readonly IBookingsService _bookingService;
    public BookingsController(IBookingsService bookingService)
    {
        _bookingService = bookingService;
    }
    // GET: api/<BookingsController>
    [HttpGet]
    public async Task<IEnumerable<BookingDTO>?> GetAllBookings()
    {
        return await _bookingService.GetAsync();
    }

    [HttpGet]
    [Route("id")]
    public async Task<BookingDTO?> GetBooking(Guid id)
    {
        return await _bookingService.GetByIdAsync(id);
    }

    // POST api/<BookingsController>
    [HttpPost]
    public async Task<IActionResult> AddBooking(BookingDTO booking)
    {
        var result = await _bookingService.AddAsync(booking);
        return result.Succeeded ? Ok() : BadRequest(result.Errors);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBooking(BookingDTO booking)
    {
        var result = await _bookingService.UpdateAsync(booking);
        return result.Succeeded ? Ok() : BadRequest(result.Errors);
    }

    [HttpDelete]
    [Route("id")]
    public async Task<IActionResult> DeleteBooking(Guid Id)
    {
        var result = await _bookingService.DeleteAsync(Id);
        return result.Succeeded ? Ok() : BadRequest(result.Errors);
    }

}
