using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.Application.AvailabilitySlots.Dto;
using backend.Application.Common.Models;
using MediatR;

namespace backend.Application.AvailabilitySlots.Commands.UpdateAvailabilitySlot;
public record UpdateAvailabilityCommand(AvailabilitySlotDTO AvailabilitySlot) : IRequest<Result>;