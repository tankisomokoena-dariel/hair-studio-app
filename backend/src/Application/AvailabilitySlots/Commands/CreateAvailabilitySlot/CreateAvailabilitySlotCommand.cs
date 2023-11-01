using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.Application.Common.Models;
using backend.Domain.Entities;
using MediatR;

namespace backend.Application.AvailabilitySlots.Commands.CreateAvailabilitySlot;
public record CreateAvailabilitySlotCommand(AvailabilitySlot AvailabilitySlot) : IRequest<Result>;
