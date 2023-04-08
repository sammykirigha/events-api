using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eventsApi.Dtos.eventAttendeeDto;
using eventsApi.Entities.Models;

namespace eventsApi.Contracts
{
    public interface IEventAttendeeRepository : IRepositoryBase<EventAttendee>
    {
        void CreateEventAttendee(EventAttendee eventAttendeeToCreate);

    }

}