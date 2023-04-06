using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eventsApi.Entities.Models
{
    public class EventAttendee
    {
        public int AttendeesAttendeeId { get; set; }
        public int EventsEventId { get; set; }
    }
}