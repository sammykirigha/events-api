using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eventsApi.Dtos;
using eventsApi.Dtos.eventsDto;
using eventsApi.Models;

namespace eventsApi.Handlers
{
    public class AutoMapperAttendee : Profile
    {
        public AutoMapperAttendee()
        {
            CreateMap<Attendee, AttendeeForCreationDto>().ReverseMap();
            CreateMap<Attendee, AttendeeDto>().ReverseMap();
            CreateMap<Event, EventDto>().ReverseMap();
        }
    }
}