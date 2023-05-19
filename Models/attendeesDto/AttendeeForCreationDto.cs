using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using eventsApi.Models;

namespace eventsApi.Dtos
{
    public class AttendeeForCreationDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Speaker { get; set; } = string.Empty;


    }
}