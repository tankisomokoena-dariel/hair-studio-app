using Application.AvailabilitySlots.DTO;
using backend.Application.Common.Models;
using MediatR;

namespace Application.AvailabilitySlots.Commands.UpdateAvailability;
public record UpdateAvailabilityCommand(AvailabilitySlotDTO AvailabilitySlot) : IRequest<Result>;