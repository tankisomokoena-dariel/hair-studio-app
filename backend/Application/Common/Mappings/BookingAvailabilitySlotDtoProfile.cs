using Application.AvailabilitySlots.DTO;
using AutoMapper;
using backend.Domain.Entities;

namespace Application.Common.Mappings
{
    internal class BookingAvailabilitySlotDtoProfile : Profile
    {
        public BookingAvailabilitySlotDtoProfile()
        {
            CreateMap<Booking, AvailabilitySlotDTO>()
                .ForMember(dest => dest.BookingId,
                           opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.StartTime,
                            opt => opt.MapFrom(src => src.StartTime))
                .ForMember(dest => dest.EndTime,
                            opt => opt.MapFrom(src => src.EndTime))
                .ForMember(dest => dest.Date,
                            opt => opt.MapFrom(src => src.Date));
                           
        }
    }
}
