using Application.AvailabilitySlots.DTO;
using MediatR;

namespace Application.AvailabilitySlots.Queries
{
    public record GetAvailabilitySlotQuery(Guid Id) : IRequest<AvailabilitySlotDTO?>;
}
