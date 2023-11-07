using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using backend.Application.Common.Mappings;
using backend.Domain.Entities;

namespace backend.Application.AvailabilitySlots.Dto;
public record AvailabilitySlotDTO(int Id, 
                                DateTime Date, 
                                DateTime StartTime, 
                                DateTime EndTime) : IMapFrom<AvailabilitySlot>;

