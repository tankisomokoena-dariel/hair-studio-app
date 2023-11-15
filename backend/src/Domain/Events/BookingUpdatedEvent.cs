using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.Domain.Events;
public class BookingUpdatedEvent : BaseEvent
{
    public BookingUpdatedEvent(Booking booking)
    {
        Booking = booking;
    }

    public Booking Booking {get;}
}
