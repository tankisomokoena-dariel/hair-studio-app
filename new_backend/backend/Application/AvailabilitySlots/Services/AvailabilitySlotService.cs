using Application.AvailabilitySlots.Commands.DeleteAvailabilitySlot;
using Application.AvailabilitySlots.Commands.UpdateAvailability;
using Application.AvailabilitySlots.DTO;
using Application.AvailabilitySlots.Queries;
using backend.Application.AvailabilitySlots.Commands.CreateAvailabilitySlot;
using backend.Application.Common.Models;
using backend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AvailabilitySlots.Services
{
    public class AvailabilitySlotService : IAvailabilitySlotService
    {
        private readonly IMediator _mediator;
        public AvailabilitySlotService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Result> AddAsync(AvailabilitySlotDTO item)
        {
            return await _mediator.Send(new CreateAvailabilitySlotCommand(item));
        }

        public async Task<Result> DeleteAsync(Guid id)
        {
            return await _mediator.Send(new DeleteAvailabilitySlotCommand(id));
        }

        public async Task<IEnumerable<AvailabilitySlotDTO>?> GetAsync()
        {
            return await _mediator.Send(new GetAllAvailabilitySlotsQuery());
        }

        public async Task<AvailabilitySlotDTO?> GetByIdAsync(Guid id)
        {
            return await _mediator.Send(new GetAvailabilitySlotQuery(id));
        }

        public async Task<Result> UpdateAsync(AvailabilitySlotDTO item)
        {
            return await _mediator.Send(new UpdateAvailabilityCommand(item));
        }
    }
}
