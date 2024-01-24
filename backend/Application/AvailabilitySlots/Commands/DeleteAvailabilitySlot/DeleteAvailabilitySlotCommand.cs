using backend.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AvailabilitySlots.Commands.DeleteAvailabilitySlot
{
    public record DeleteAvailabilitySlotCommand(Guid Id) : IRequest<Result>;
}
