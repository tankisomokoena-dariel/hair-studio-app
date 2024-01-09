using Application.AvailabilitySlots.DTO;
using AutoMapper;
using backend.Domain.Entities;
using System.Runtime.CompilerServices;

namespace Application.Common.Mappings
{
    public class AvailabilitySlotProfile : Profile
    {
        public AvailabilitySlotProfile()
        {
            CreateMap<AvailabilitySlot, AvailabilitySlotDTO>()
                .ReverseMap();
        }
    }
}
