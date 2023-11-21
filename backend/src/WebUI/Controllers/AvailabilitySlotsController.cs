using backend.Application.AvailabilitySlots.Commands.CreateAvailabilitySlot;
using backend.Application.AvailabilitySlots.Commands.UpdateAvailabilitySlot;
using backend.Application.AvailabilitySlots.Dto;
using backend.Application.AvailabilitySlots.Interfaces;
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
    private readonly IAvailabilitySlotService _availabilitySlotService;

    public AvailabilitySlotsController(IAvailabilitySlotService availabilitySlotService)
    {
        _availabilitySlotService = availabilitySlotService;
    }
    // GET: api/<AvailabilitySlotsController>
    [HttpGet]
    public async Task<IEnumerable<AvailabilitySlotDTO>> Get()
    {
        var availabilitySlots = await _availabilitySlotService.GetAvailabilitySlots(new GetAvailabilitySlotsQuery());
        return availabilitySlots;
    }

    [HttpPost]
    public async Task<IActionResult> AddAvailabilitySlots(AvailabilitySlot availabilitySlot)
    {
        var result = await _availabilitySlotService.AddAvailabilitySlots(availabilitySlot);
        return result.Succeeded ? Ok() : BadRequest(result.Errors);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAvailabilitySlot(AvailabilitySlotDTO availabilitySlot)
    {
        var result = await _availabilitySlotService.UpdateAvailabilitySlots(availabilitySlot);
        return result.Succeeded ? Ok() : BadRequest(result.Errors);
    }
}
