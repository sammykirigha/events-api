using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace eventsApi.Models
{
    [Table("Attendees")]
    public class Attendee
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Please Provide a valid email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [StringLength(12, ErrorMessage = "Phone can't be longer than 12 characters")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        [StringLength(60, ErrorMessage = "FirstName can't be longer than 60 characters")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        [StringLength(60, ErrorMessage = "LastName can't be longer than 60 characters")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Speaker is required")]
        public string? Speaker { get; set; }

        public List<Event> Events {get;} = new();
        
        public List<AttendeeEvent> AttendeeEvents { get; } = new();

    }
}