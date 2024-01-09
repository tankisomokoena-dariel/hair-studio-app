﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.AvailabilitySlots.DTO;
using backend.Domain.Entities;
using MediatR;

namespace Application.AvailabilitySlots.Queries;

public record GetAllAvailabilitySlotsQuery : IRequest<List<AvailabilitySlotDTO>>;
