using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eventsApi.Models
{
    [Table("Events")]
    public class Event
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "EventName is required")]
        [StringLength(60, ErrorMessage = "EventName can't be longer than 60 characters")]
        public string? EventName { get; set; }

        [Required(ErrorMessage = "EventDate is required")]
        public DateTimeOffset EventDate { get; set; }

        [Required(ErrorMessage = "Location is required")]
        public string? Location { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "Capacity is required")]
        public int? Capacity { get; set; }

        public List<Attendee> Attendees {get;} = new();
        
        public List<AttendeeEvent> AttendeeEvents { get; } = new();
    }
}