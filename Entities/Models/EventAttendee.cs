using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace eventsApi.Entities.Models
{
    [Table("AttendeeEventId")]
    [Keyless]
    public class EventAttendee
    {
        // public int AttendeeEventId { get; set; }
        public int AttendeesAttendeeId { get; set; }
        public int EventsEventId { get; set; }
    }
}