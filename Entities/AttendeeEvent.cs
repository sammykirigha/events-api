using System.ComponentModel.DataAnnotations.Schema;

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