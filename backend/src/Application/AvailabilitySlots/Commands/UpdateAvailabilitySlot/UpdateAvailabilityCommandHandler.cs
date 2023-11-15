using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.Application.Common.Interfaces.Repositories;
using backend.Application.Common.Models;
using MediatR;

namespace backend.Application.AvailabilitySlots.Commands.UpdateAvailabilitySlot;
public class UpdateAvailabilityCommandHandler : IRequestHandler<UpdateAvailabilityCommand, Result>
{
    private readonly IAvailabilitySlotRepository _repository;
    public UpdateAvailabilityCommandHandler(IAvailabilitySlotRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(UpdateAvailabilityCommand request, CancellationToken cancellationToken)
    {
        var slot = await _repository.GetByIdAsync(request.AvailabilitySlot.Id);

        if (slot == null)
        {
            return Result.Failure(new List<string>() { "Slot does not exist" });
        }

        slot.StartTime = request.AvailabilitySlot.StartTime;
        slot.EndTime = request.AvailabilitySlot.EndTime;
        slot.Date = request.AvailabilitySlot.Date;
        slot.LastModified = DateTime.Now;
        slot.LastModifiedBy = "TBC";
        
        await _repository.UpdateAsync(slot);

        return Result.Success();
    }
}
