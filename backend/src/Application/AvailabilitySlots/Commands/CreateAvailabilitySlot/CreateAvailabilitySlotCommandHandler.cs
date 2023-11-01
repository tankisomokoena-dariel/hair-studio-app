using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.Application.Common.Interfaces.Repositories;
using backend.Application.Common.Models;
using backend.Domain.Entities;
using MediatR;

namespace backend.Application.AvailabilitySlots.Commands.CreateAvailabilitySlot;
internal class CreateAvailabilitySlotCommandHandler : IRequestHandler<CreateAvailabilitySlotCommand, Result>
{
    private readonly IAvailabilitySlotRepository _availabilitySlotRepository;
    public CreateAvailabilitySlotCommandHandler(IAvailabilitySlotRepository availabilitySlotRepository)
    {
        _availabilitySlotRepository = availabilitySlotRepository;
    }
    async Task<Result> IRequestHandler<CreateAvailabilitySlotCommand, Result>.Handle(CreateAvailabilitySlotCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _availabilitySlotRepository.AddAsync(new AvailabilitySlot
            {
                StartTime = request.AvailabilitySlot.StartTime,
                EndTime = request.AvailabilitySlot.EndTime,
                Created = request.AvailabilitySlot.Created,
                CreatedBy = request.AvailabilitySlot.CreatedBy,
                LastModified = request.AvailabilitySlot.LastModified,
                LastModifiedBy = request.AvailabilitySlot.LastModifiedBy,
            });

            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure(new List<string> { ex.Message, ex.StackTrace != null ? ex.StackTrace : "" });
        }
    }
}
