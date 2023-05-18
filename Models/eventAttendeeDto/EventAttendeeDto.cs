using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eventsApi.Dtos.eventAttendeeDto
{
    public class EventAttendeeDto
    {
        public int AttendeesAttendeeId { get; set; }
        public int EventsEventId { get; set; }
    }
}