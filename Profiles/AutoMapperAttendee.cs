using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eventsApi.Dtos;
using eventsApi.Dtos.eventsDto;
using eventsApi.Helpers;
using eventsApi.Models;

namespace eventsApi.Handlers
{
    public class AutoMapperAttendee : Profile
    {
        public AutoMapperAttendee()
        {
            CreateMap<Attendee, AttendeeForCreationDto>().ReverseMap();
            CreateMap<Attendee, AttendeeDto>()
                       .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                       .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.Getcurrentage()));
            CreateMap<Event, EventDto>().ReverseMap();
            CreateMap<Event, EventToCreateDto>().ReverseMap();
            CreateMap<Event, CreatedEventDto>().ReverseMap();
            CreateMap<Event, EventDtoCsv>().ReverseMap();
        }
    }
}