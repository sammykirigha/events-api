using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using eventsApi.Dtos.eventsDto;
using eventsApi.Models;

namespace eventsApi.Dtos
{
    public class AttendeeDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public int Age { get; set; }

        public string Speaker { get; set; } = string.Empty;
        
        public List<EventDto>? events { get; set; }
    }
}