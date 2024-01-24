using Application.Common.Services;
using AutoMapper;
using backend.Application.Common.Interfaces.Repositories;
using backend.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AvailabilitySlots.Commands.DeleteAvailabilitySlot
{
    internal class DeleteAvailabilitySlotCommandHandler : IRequestHandler<DeleteAvailabilitySlotCommand, Result>
    {
        private readonly IAvailabilitySlotRepository _availabilitySlotRepository;
        private readonly IMapper _mapper;
        public DeleteAvailabilitySlotCommandHandler(IAvailabilitySlotRepository availabilitySlotRepository, IMapper mapper)
        {
            _availabilitySlotRepository = availabilitySlotRepository;
            _mapper = mapper;
        }
        public async Task<Result> Handle(DeleteAvailabilitySlotCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var slot = await _availabilitySlotRepository.GetByIdAsync(request.Id);

                if (slot == null)
                {
                    throw new Exception("Slot does not exist");
                }

                await _availabilitySlotRepository.DeleteAsync(slot);
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(new List<string> { ex.Message, ex.StackTrace != null ? ex.StackTrace : "" });
            }
        }
    }
}
