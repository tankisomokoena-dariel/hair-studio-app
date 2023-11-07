using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using backend.Application.AvailabilitySlots.Dto;
using backend.Application.Common.Interfaces.Repositories;
using MediatR;

namespace backend.Application.AvailabilitySlots.Queries;
public class GetAvailabilitySlotsQueryHandler : IRequestHandler<GetAvailabilitySlotsQuery, List<AvailabilitySlotDTO>>
{
    private readonly IMapper _mapper;
    private readonly IAvailabilitySlotRepository _availabilitySlotRepository;

    public GetAvailabilitySlotsQueryHandler(IMapper mapper, IAvailabilitySlotRepository availabilitySlotRepository)
    {
        _mapper = mapper;
        _availabilitySlotRepository = availabilitySlotRepository;
    }
    public async Task<List<AvailabilitySlotDTO>> Handle(GetAvailabilitySlotsQuery request, CancellationToken cancellationToken)
    {
        // Query the database
        var availabilitySlots = await _availabilitySlotRepository.GetAllAsync();
        // Convert data objects to DTO objects
        var dto = _mapper.Map<List<AvailabilitySlotDTO>>(availabilitySlots);
        // return list
        return dto;
    }
}
