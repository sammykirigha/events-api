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
        Task<IEnumerable<Event>> GetAllEventsAsync(string eventName, string searchQuery);

        Task<IEnumerable<Event>> GetAllEventsAsync(IEnumerable<Guid> eventIds);

        Task<Event> GetEventByIdAsync(Guid eventId);

        void CreateEvent(Event eventToCreate);
    }
}