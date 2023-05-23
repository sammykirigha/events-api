using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eventsApi.Helpers;
using eventsApi.Models;
using eventsApi.ResourceParameters;

namespace eventsApi.Contracts
{
    public interface IEventRepository : IRepositoryBase<Event>
    {
        Task<IEnumerable<Event>> GetAllEventsAsync();
        Task<PageList<Event>> GetAllEventsAsync(EventsResourceParameters eventsResourceParameters);

        Task<IEnumerable<Event>> GetAllEventsAsync(IEnumerable<Guid> eventIds);

        Task<Event> GetEventByIdAsync(Guid eventId);

        void CreateEvent(Event eventToCreate);
    }
}