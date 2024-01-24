using Application.AvailabilitySlots.DTO;
using AutoMapper;
using backend.Application.Common.Interfaces.Repositories;
using MediatR;

namespace Application.AvailabilitySlots.Queries
{
    internal class GetAvailabilitySlotQueryHandler : IRequestHandler<GetAvailabilitySlotQuery, AvailabilitySlotDTO?>
    {
        private readonly IAvailabilitySlotRepository _repository;
        private readonly IMapper _mapper;
        public GetAvailabilitySlotQueryHandler(IAvailabilitySlotRepository availabilitySlotRepository, IMapper mapper) 
        { 
            _mapper = mapper;
            _repository = availabilitySlotRepository;
        }

        public async Task<AvailabilitySlotDTO?> Handle(GetAvailabilitySlotQuery request, CancellationToken cancellationToken)
        {
            var slot = await _repository.GetByIdAsync(request.Id);

            if (slot == null)
                return null;

            return _mapper.Map<AvailabilitySlotDTO>(slot);

        }
    }
}
