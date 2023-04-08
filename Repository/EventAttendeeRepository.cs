using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eventsApi.Contracts;
using eventsApi.Dtos.eventAttendeeDto;
using eventsApi.Entities;
using eventsApi.Entities.Models;

namespace eventsApi.Repository
{
    public class EventAttendeeRepository : RepositoryBase<EventAttendee>, IEventAttendeeRepository
    {
        public EventAttendeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        { }
        public void CreateEventAttendee(EventAttendee eventAttendee)
        {
            Create(eventAttendee);
        }
    }
}