using Application.AvailabilitySlots.DTO;
using backend.Application.Common.Models;
using MediatR;

namespace backend.Application.AvailabilitySlots.Commands.CreateAvailabilitySlot;
public record CreateAvailabilitySlotCommand(AvailabilitySlotDTO AvailabilitySlot) : IRequest<Result>;
