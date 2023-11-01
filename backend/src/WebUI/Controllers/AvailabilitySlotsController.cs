using backend.Application.AvailabilitySlots.Commands.CreateAvailabilitySlot;
using backend.Application.AvailabilitySlots.Dto;
using backend.Application.AvailabilitySlots.Queries;
using backend.Domain.Entities;
using backend.WebUI.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebUI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AvailabilitySlotsController : ApiControllerBase
{
    // GET: api/<AvailabilitySlotsController>
    [HttpGet]
    public async Task<List<AvailabilitySlotDto>> Get()
    {
        var availabilitySlots = await Mediator.Send(new GetAvailabilitySlotsQuery());
        return availabilitySlots;
    }

    [HttpPost]
    public async Task<IActionResult> Add(AvailabilitySlot availabilitySlot)
    {
        var result = await Mediator.Send(new CreateAvailabilitySlotCommand(availabilitySlot));
        return result.Succeeded ? Ok() : BadRequest(result.Errors);
    }
}
