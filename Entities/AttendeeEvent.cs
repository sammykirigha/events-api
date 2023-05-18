using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace eventsApi.Models
{
    [Table("AttendeeEvents")]
    public class AttendeeEvent
    {
        public Guid EventId { get; set; }
        public Event Event { get; set; } = null;
        public Guid AttendeeId { get; set; }
        public Attendee Attendee { get; set; } = null;

    }
}