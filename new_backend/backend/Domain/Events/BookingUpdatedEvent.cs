
using backend.Domain.Entities;
using Domain.Common;

public class BookingUpdatedEvent : BaseEvent
{
    public BookingUpdatedEvent(Booking booking)
    {
        Booking = booking;
    }

    public Booking Booking {get;}
}
