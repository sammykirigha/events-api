using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eventsApi.Models
{
    [Table("event")]
    public class Event
    {
        public Guid EventId { get; set; }

        [Required(ErrorMessage = "EventName is required")]
        [StringLength(60, ErrorMessage = "EventName can't be longer than 60 characters")]
        public string? EventName { get; set; }

        [Required(ErrorMessage = "EventDate is required")]
        public DateTime EventDate { get; set; }

        [Required(ErrorMessage = "Location is required")]
        public string? Location { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Capacity is required")]
        public int? Capacity { get; set; }

    }
}