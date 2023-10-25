using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using backend.Application.Common.Mappings;
using backend.Domain.Entities;

namespace backend.Application.AvailabilitySlots.Dto;
public class AvailabilitySlotDto : IMapFrom<AvailabilitySlot>
{
    public int Id { get; init; }
    public DateTime Date { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

}
