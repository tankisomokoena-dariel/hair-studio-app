using backend.Application.AvailabilitySlots.Dto;
using backend.Application.AvailabilitySlots.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebUI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AvailabilitySlotsController : ControllerBase
{
    private readonly IMediator _mediator;
    public AvailabilitySlotsController(IMediator mediator)
    {
        this._mediator = mediator;
    }
    // GET: api/<AvailabilitySlotsController>
    [HttpGet]
    public async Task<List<AvailabilitySlotDto>> Get()
    {
        var availabilitySlots = await _mediator.Send(new GetAvailabilitySlotsQuery());
        return availabilitySlots;
    }
}
