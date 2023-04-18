using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using eventsApi.Entities.Models;

namespace eventsApi.Models
{
    [Table("Events")]
    public class Event
    {
        [Key]
        public Guid EventId { get; set; }

        [Required(ErrorMessage = "EventName is required")]
        [StringLength(60, ErrorMessage = "EventName can't be longer than 60 characters")]
        public string? EventName { get; set; }

        [Required(ErrorMessage = "EventDate is required")]
        public DateTime EventDate { get; set; }

        [Required(ErrorMessage = "Location is required")]
        public string? Location { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "Capacity is required")]
        public int? Capacity { get; set; }

        [JsonIgnore]
        public List<Attendee>? Attendees { get; set; }

        [NotMapped]
        public IList<EventAttendee>? EventAttendees { get; set; }


    }
}