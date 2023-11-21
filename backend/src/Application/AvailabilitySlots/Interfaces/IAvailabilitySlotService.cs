using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.Application.AvailabilitySlots.Dto;
using backend.Application.AvailabilitySlots.Queries;
using backend.Application.Common.Models;
using backend.Domain.Entities;

namespace backend.Application.AvailabilitySlots.Interfaces;
public interface IAvailabilitySlotService
{
    public Task<IEnumerable<AvailabilitySlotDTO>> GetAvailabilitySlots(GetAvailabilitySlotsQuery getAvailabilitySlotsQuery);

    public Task<Result> AddAvailabilitySlots(AvailabilitySlot availabilitySlot);

    public Task<Result> UpdateAvailabilitySlots(AvailabilitySlotDTO availabilitySlot);
}
