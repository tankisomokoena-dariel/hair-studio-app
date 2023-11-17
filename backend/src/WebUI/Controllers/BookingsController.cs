using backend.Application.Bookings.Commands.CreateBooking;
using backend.Application.Bookings.DTOs;
using backend.Application.Bookings.Queries;
using backend.Application.Bookings.Service;
using backend.Application.Common.Models;
using backend.Domain.Entities;
using backend.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebUI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BookingsController : ApiControllerBase
{
    private readonly IBookingService _bookingService;
    public BookingsController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }
    // GET: api/<BookingsController>
    [HttpGet]
    public async Task<IEnumerable<BookingDTO>?> GetAllBookings()
    {
        return await _bookingService.GetAllBookingsAsync();
    }

    [HttpGet]
    [Route("id")]
    public async Task<BookingDTO?> GetBooking(int Id)
    {
        return await _bookingService.GetBookingAsync(Id);
    }

    // POST api/<BookingsController>
    [HttpPost]
    public async Task<IActionResult> AddBooking([FromBody] BookingDTO booking)
    {
        var result = await _bookingService.AddBookingAsync(booking);
        return result.Succeeded ? Ok() : BadRequest(result.Errors);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBooking([FromBody] BookingDTO booking)
    {
        var result = await _bookingService.UpdateBookingAsync(booking);
        return result.Succeeded ? Ok() : BadRequest(result.Errors);
    }

    [HttpDelete]
    [Route("id")]
    public async Task<IActionResult> DeleteBooking(int Id)
    {
        var result = await _bookingService.DeleteBookingAsync(Id);
        return result.Succeeded ? Ok() : BadRequest(result.Errors);
    }

}
