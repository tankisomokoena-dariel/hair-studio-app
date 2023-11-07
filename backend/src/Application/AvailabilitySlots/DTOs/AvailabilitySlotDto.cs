using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using backend.Application.Common.Mappings;
using backend.Domain.Entities;

namespace backend.Application.AvailabilitySlots.Dto;
public record AvailabilitySlotDTO : IMapFrom<AvailabilitySlot>
 {
    public int Id { get; init; }
    public DateTime Date {get; init;} 
    public DateTime StartTime {get; init;}
    public DateTime EndTime {get; init;}
}

