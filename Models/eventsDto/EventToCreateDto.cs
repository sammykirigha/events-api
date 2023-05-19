using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using eventsApi.Models;

namespace eventsApi.Dtos.eventsDto
{
    public class EventToCreateDto
    {
        public Guid EventId { get; set; }

        public string EventName { get; set; } = string.Empty;

        public DateTimeOffset EventDate { get; set; }

        public string Location { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int Capacity { get; set; }

    }
}