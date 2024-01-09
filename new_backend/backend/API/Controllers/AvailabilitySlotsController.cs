using Application.AvailabilitySlots.DTO;
using Application.AvailabilitySlots.Services;
using backend.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailabilitySlotsController : ControllerBase
    {
        private readonly IAvailabilitySlotService _availabilitySlotService;
        public AvailabilitySlotsController(IAvailabilitySlotService availabilitySlotService) 
        {
            _availabilitySlotService = availabilitySlotService;
        }
        // GET: api/<AvailabilitySlotsController>
        [HttpGet]
        public async Task<IEnumerable<AvailabilitySlotDTO>?> GetAllAvailabilitySlots()
        {
            return await _availabilitySlotService.GetAsync();
        }

        [HttpGet("{id}")]
        public async Task<AvailabilitySlotDTO?> GetAvailabilitySlot(Guid id)
        {
            return await _availabilitySlotService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> AddAvailabilitySlot(AvailabilitySlotDTO availabilitySlot)
        {
            var result = await _availabilitySlotService.AddAsync(availabilitySlot);
            return result.Succeeded ? Ok() : BadRequest(result.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAvailabilitySlot(AvailabilitySlotDTO availabilitySlot)
        {
            var result = await _availabilitySlotService.UpdateAsync(availabilitySlot);
            return result.Succeeded ? Ok() : BadRequest(result.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAvailabilitySlot(Guid id)
        {
            var result = await _availabilitySlotService.DeleteAsync(id);
            return result.Succeeded ? Ok() : BadRequest(result.Errors);
        }
    }
}
