using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eventsApi.Models;

namespace eventsApi.Contracts
{
    public interface IEventRepository : IRepositoryBase<Event>
    {
        Task<IEnumerable<Event>> GetAllEventsAsync();

        void CreateEvent(Event eventToCreate);
    }
}