using AutoMapper;
using backend.Application.Common.Interfaces.Repositories;
using backend.Application.Common.Models;
using backend.Domain.Entities;
using MediatR;

namespace Application.AvailabilitySlots.Commands.UpdateAvailability;
public class UpdateAvailabilityCommandHandler : IRequestHandler<UpdateAvailabilityCommand, Result>
{
    private readonly IAvailabilitySlotRepository _repository;
    private readonly IMapper _mapper;
    public UpdateAvailabilityCommandHandler(IAvailabilitySlotRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result> Handle(UpdateAvailabilityCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var slot = _mapper.Map<AvailabilitySlot>(request.AvailabilitySlot);
            await _repository.UpdateAsync(slot);
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure(new List<string> { ex.Message, ex.StackTrace != null ? ex.StackTrace : "" });
        }


    }
}
