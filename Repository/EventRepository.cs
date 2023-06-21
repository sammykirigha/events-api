
using eventsApi.Contracts;
using eventsApi.DbContexts;
using eventsApi.Dtos.eventsDto;
using eventsApi.Helpers;
using eventsApi.Models;
using eventsApi.ResourceParameters;
using Microsoft.EntityFrameworkCore;


namespace eventsApi.Repository;
public class EventRepository : RepositoryBase<Event>, IEventRepository
{
    private readonly IEventPropertyMappingService _eventpropertyMappingService;
    public EventRepository(RepositoryContext repositoryContext, IEventPropertyMappingService eventpropertyMappingService) : base(repositoryContext)
    {
        _eventpropertyMappingService = eventpropertyMappingService ?? throw new ArgumentNullException(nameof(eventpropertyMappingService));
    }

    public async Task<IEnumerable<Event>> GetAllEventsAsync()
    {
        var results = await FindAll().Include(_ => _.Attendees).OrderBy(ev => ev.Id).ToListAsync();
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
        if (eventIds == null)
        {
            throw new ArgumentNullException(nameof(eventIds));
        }

        //   .FirstOrDefaultAsync(e => eventIds.Contains(e.Id))
        var results = await FindAll().Where(e => eventIds.Contains(e.Id)).ToListAsync();
        return results;
    }

    public async Task<PageList<Event>> GetAllEventsAsync(EventsResourceParameters eventsResourceParameters)
    {

        if (eventsResourceParameters == null)
        {
            throw new ArgumentNullException(nameof(eventsResourceParameters));
        }

        var collection = FindAll() as IQueryable<Event>;

        if (!string.IsNullOrWhiteSpace(eventsResourceParameters.EventName))
        {
            var eventName = eventsResourceParameters.EventName.Trim();
            collection = collection.Where(e => e.EventName == eventName);
        }

        if (!string.IsNullOrWhiteSpace(eventsResourceParameters.SearchQuery))
        {
            var searchQuery = eventsResourceParameters.SearchQuery.Trim();
            collection = collection.Where(e => e.EventName!.Contains(searchQuery)
            || e.Description!.Contains(searchQuery)
            || e.Location!.Contains(searchQuery));
        }

        if (!string.IsNullOrWhiteSpace(eventsResourceParameters.OrderBy))
        {
            var eventPropertyMappingDictionary = _eventpropertyMappingService.GetPropertyMapping<EventDto, Event>();

            collection = collection.ApplySort(eventsResourceParameters.OrderBy, eventPropertyMappingDictionary);
        }

        return await PageList<Event>.CreateAsync(collection,
        eventsResourceParameters.PageNumber,
        eventsResourceParameters.PageSize);
    }
}
