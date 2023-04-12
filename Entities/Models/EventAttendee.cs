using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using eventsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace eventsApi.Entities.Models
{
    [Table("AttendeeEvent")]
    [Keyless]
    public class EventAttendee
    {
        [ForeignKey("EventId")]
        public int EventsEventId { get; set; }
        public Event? Event { get; set; }

        [ForeignKey("AttendeeId")]
        public int AttendeesAttendeeId { get; set; }
        public Attendee? Attendee { get; set; }
    }
}