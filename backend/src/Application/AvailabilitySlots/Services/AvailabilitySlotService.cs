using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.Application.AvailabilitySlots.Commands.CreateAvailabilitySlot;
using backend.Application.AvailabilitySlots.Commands.UpdateAvailabilitySlot;
using backend.Application.AvailabilitySlots.Dto;
using backend.Application.AvailabilitySlots.Interfaces;
using backend.Application.AvailabilitySlots.Queries;
using backend.Application.Common.Models;
using backend.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace backend.Application.AvailabilitySlots.Services;
public class AvailabilitySlotService: IAvailabilitySlotService
{
    private readonly IMediator _mediator;

    public AvailabilitySlotService(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<IEnumerable<AvailabilitySlotDTO>> GetAvailabilitySlots(GetAvailabilitySlotsQuery getAvailabilitySlotsQuery)
    {
       return await _mediator.Send(getAvailabilitySlotsQuery);
    }

    public async Task<Result> AddAvailabilitySlots(AvailabilitySlot availabilitySlot)
    {
        return await _mediator.Send(new CreateAvailabilitySlotCommand(availabilitySlot));
    }

    public async Task<Result> UpdateAvailabilitySlots(AvailabilitySlotDTO availabilitySlot)
    {
        return await _mediator.Send(new UpdateAvailabilityCommand(availabilitySlot));
    }
}
