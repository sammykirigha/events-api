using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eventsApi.Contracts;
using eventsApi.Entities;
using eventsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace eventsApi.Repository
{
    public class EventRepository : RepositoryBase<Event>, IEventRepository
    {
        public EventRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        { }

        public async Task<IEnumerable<Event>> GetAllEventsAsync()
        {
            var results = await FindAll().Include(_ => _.Attendees).OrderBy(ev => ev.EventId).ToListAsync();
            return results;
        }

        public async Task<Event> GetEventByIdAsync(Guid eventId)
        {
            var result = await FindByCondition(attendee => attendee.EventId.Equals(eventId)).Include(_ => _.Attendees).FirstOrDefaultAsync();
            return result!;
        }

        public void CreateEvent(Event eventToCreate)
        {
            eventToCreate.EventId = Guid.NewGuid();
            Create(eventToCreate);
        }
    }
}