using Application.AvailabilitySlots.DTO;
using AutoMapper;
using backend.Application.AvailabilitySlots.Commands.CreateAvailabilitySlot;
using backend.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace backend.Application.Bookings.EventHandlers;
public class BookingCreatedEventHandler : INotificationHandler<BookingCreatedEvent>
{
    private readonly IMediator _mediator;
    private readonly ILogger<BookingCreatedEventHandler> _logger;
    private readonly IMapper _mapper;

    public BookingCreatedEventHandler(IMediator mediator, 
        ILogger<BookingCreatedEventHandler> logger,
        IMapper mapper)
    {
        _mediator = mediator;
        _logger = logger;
        _mapper = mapper;
    }
    public async Task Handle(BookingCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("backend Domain Event: {DomainEvent}", notification.GetType().Name);

        var slot = _mapper.Map<Booking, AvailabilitySlotDTO>(notification.Booking);

        var result = await _mediator.Send(new CreateAvailabilitySlotCommand(slot), cancellationToken);

        if (!result.Succeeded)
        {
            throw new Exception($"Could not add Booking to Availability Slots\nErrors: {result.Errors}");
        }
    }
}
