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
            var results = await FindAll().Include(_ => _.AttendeeEvents).OrderBy(ev => ev.Id).ToListAsync();
            return results;
        }

        public async Task<Event> GetEventByIdAsync(Guid eventId)
        {
            var result = await FindByCondition(attendee => attendee.Id.Equals(eventId)).Include(_ => _.AttendeeEvents).FirstOrDefaultAsync();
            return result!;
        }

        public void CreateEvent(Event eventToCreate)
        {
            eventToCreate.Id = Guid.NewGuid();
            Create(eventToCreate);
        }
    }
}