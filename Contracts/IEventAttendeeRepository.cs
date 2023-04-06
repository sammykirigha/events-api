using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eventsApi.Entities.Models;

namespace eventsApi.Contracts
{
    public class IEventAttendeeRepository
    {
        public interface IAttendeeRepository : IRepositoryBase<EventAttendee>
        {
            Task<IEnumerable<EventAttendee>> Get();

        }
    }
}