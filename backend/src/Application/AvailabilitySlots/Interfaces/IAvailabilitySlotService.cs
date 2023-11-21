using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.Application.AvailabilitySlots.Dto;
using backend.Application.AvailabilitySlots.Queries;

namespace backend.Application.AvailabilitySlots.Interfaces;
public interface IAvailabilitySlotService
{
    public Task<List<AvailabilitySlotDTO>> GetAvailabilitySlots(GetAvailabilitySlotsQuery getAvailabilitySlotsQuery);
}
