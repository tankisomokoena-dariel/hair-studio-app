
using backend.Domain.Entities;
using Domain.Common;

public class BookingCreatedEvent : BaseEvent
{
    public BookingCreatedEvent(Booking booking)
    {
        Booking = booking;
    }

    public Booking Booking { get; }
}
