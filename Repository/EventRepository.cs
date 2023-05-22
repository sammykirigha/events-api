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

        public async Task<IEnumerable<Event>> GetAllEventsAsync(IEnumerable<Guid> eventIds)
        {
            if(eventIds == null)
            {
                throw new ArgumentNullException(nameof(eventIds));
            }

            //   .FirstOrDefaultAsync(e => eventIds.Contains(e.Id))
            var results =  await FindAll().Where(e => eventIds.Contains(e.Id)).ToListAsync();
            return results;
        }

        public async Task<IEnumerable<Event>> GetAllEventsAsync(string eventName, string searchQuery)
        {
            if(string.IsNullOrWhiteSpace(eventName) && string.IsNullOrWhiteSpace(searchQuery))
            {
                return await GetAllEventsAsync();
            }
            var collection =  FindAll() as IQueryable<Event>;

            if(!string.IsNullOrWhiteSpace(eventName))
            {
            eventName = eventName.Trim();
            collection = collection.Where(e => e.EventName == eventName);
            }

            if(!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery = searchQuery.Trim();
                collection = collection.Where(e => e.EventName!.Contains(searchQuery) 
                || e.Description!.Contains(searchQuery) 
                || e.Location!.Contains(searchQuery));
            }
           
            return await collection.ToListAsync();
        }
    }
}