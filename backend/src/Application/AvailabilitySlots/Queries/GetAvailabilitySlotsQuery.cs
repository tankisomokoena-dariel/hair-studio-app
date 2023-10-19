using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.Application.AvailabilitySlots.Dto;
using backend.Domain.Entities;
using MediatR;

namespace backend.Application.AvailabilitySlots.Queries;
//public class GetAvailabilitySlotsQuery : IRequest<List<AvailabilitySlotDto>>
//{
//}

public record GetAvailabilitySlotsQuery : IRequest<List<AvailabilitySlotDto>>;
