using backend.Application.AvailabilitySlots.Commands.CreateAvailabilitySlot;
using backend.Domain.Entities;
using backend.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace backend.Application.Bookings.EventHandlers;
public class BookingCreatedEventHandler : INotificationHandler<BookingCreatedEvent>
{
    private readonly IMediator _mediator;
    private readonly ILogger<BookingCreatedEventHandler> _logger;

    public BookingCreatedEventHandler(IMediator mediator, ILogger<BookingCreatedEventHandler> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }
    public async Task Handle(BookingCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("backend Domain Event: {DomainEvent}", notification.GetType().Name);

        var availabilitySlot = new AvailabilitySlot
        {
            Date = notification.Booking.Date,
            StartTime = notification.Booking.StartTime,
            EndTime = notification.Booking.EndTime,
            CreatedBy = notification.Booking.CreatedBy,
            Created = notification.Booking.Created,
            LastModified = notification.Booking.LastModified,
            LastModifiedBy = notification.Booking.LastModifiedBy,
        };

        var result = await _mediator.Send(new CreateAvailabilitySlotCommand(availabilitySlot), cancellationToken);

        if (!result.Succeeded)
        {
            throw new Exception($"Could not add Booking to Availability Slots\nErrors: {result.Errors}");
        }
    }
}
