using backend.Domain.Entities;
using Domain.Common;
public class BookingDeletedEvent : BaseEvent
{

    public BookingDeletedEvent(Booking booking)
    {
        Booking = booking;
    }
    public Booking Booking { get; }
}
