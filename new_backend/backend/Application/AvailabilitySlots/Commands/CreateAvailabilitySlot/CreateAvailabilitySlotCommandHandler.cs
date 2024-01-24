using AutoMapper;
using backend.Application.Common.Interfaces.Repositories;
using backend.Application.Common.Models;
using backend.Domain.Entities;
using MediatR;

namespace backend.Application.AvailabilitySlots.Commands.CreateAvailabilitySlot;
internal class CreateAvailabilitySlotCommandHandler : IRequestHandler<CreateAvailabilitySlotCommand, Result>
{
    private readonly IAvailabilitySlotRepository _availabilitySlotRepository;
    private readonly IMapper _mapper;
    public CreateAvailabilitySlotCommandHandler(IAvailabilitySlotRepository availabilitySlotRepository, IMapper mapper)
    {
        _availabilitySlotRepository = availabilitySlotRepository;
        _mapper = mapper;
    }
    async Task<Result> IRequestHandler<CreateAvailabilitySlotCommand, Result>.Handle(CreateAvailabilitySlotCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var slot = _mapper.Map<AvailabilitySlot>(request.AvailabilitySlot);
            await _availabilitySlotRepository.AddAsync(slot);

            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure(new List<string> { ex.Message, ex.StackTrace != null ? ex.StackTrace : "" });
        }
    }
}
