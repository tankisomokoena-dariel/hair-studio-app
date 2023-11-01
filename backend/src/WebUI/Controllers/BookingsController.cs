using backend.Application.Bookings.Commands.CreateBooking;
using backend.Application.Bookings.DTOs;
using backend.Application.Bookings.Queries;
using backend.Domain.Entities;
using backend.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebUI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BookingsController : ApiControllerBase
{
    // GET: api/<BookingsController>
    [HttpGet]
    public async Task<IEnumerable<BookingDTO>> Get()
    {
        var bookings = await Mediator.Send(new GetBookingsQuery());
        return bookings;
    }

    // POST api/<BookingsController>
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] Booking booking)
    {
        var result = await Mediator.Send(new CreateBookingCommand(booking));
        return result.Succeeded ? Ok() : BadRequest(result.Errors);
    }

}
