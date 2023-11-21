using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.Application.AvailabilitySlots.Dto;
using backend.Application.AvailabilitySlots.Interfaces;
using backend.Application.AvailabilitySlots.Queries;
using MediatR;

namespace backend.Application.AvailabilitySlots.Services;
public class AvailabilitySlotService: IAvailabilitySlotService
{
    private readonly IMediator _mediator;

    public AvailabilitySlotService(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<List<AvailabilitySlotDTO>> GetAvailabilitySlots(GetAvailabilitySlotsQuery getAvailabilitySlotsQuery)
    {
        return await _mediator.Send(getAvailabilitySlotsQuery);
    }
}
