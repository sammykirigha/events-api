using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eventsApi.Dtos.eventsDto
{
    public class CreatedEventDto
    {
        public Guid EventId { get; set; }

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
    }
}