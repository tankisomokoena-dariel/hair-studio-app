using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.AvailabilitySlots.DTO;
using AutoMapper;
using backend.Application.Common.Interfaces.Repositories;
using MediatR;

namespace Application.AvailabilitySlots.Queries;
public class GetAllAvailabilitySlotsQueryHandler : IRequestHandler<GetAllAvailabilitySlotsQuery, List<AvailabilitySlotDTO>>
{
    private readonly IMapper _mapper;
    private readonly IAvailabilitySlotRepository _availabilitySlotRepository;

    public GetAllAvailabilitySlotsQueryHandler(IMapper mapper, IAvailabilitySlotRepository availabilitySlotRepository)
    {
        _mapper = mapper;
        _availabilitySlotRepository = availabilitySlotRepository;
    }
    public async Task<List<AvailabilitySlotDTO>> Handle(GetAllAvailabilitySlotsQuery request, CancellationToken cancellationToken)
    {
        // Query the database
        var availabilitySlots = await _availabilitySlotRepository.GetAllAsync();
        // Convert data objects to DTO objects
        var dto = _mapper.Map<List<AvailabilitySlotDTO>>(availabilitySlots);
        // return list
        return dto;
    }
}
