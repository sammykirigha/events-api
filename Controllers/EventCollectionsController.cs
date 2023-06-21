using AutoMapper;
using eventsApi.Contracts;
using eventsApi.Dtos.eventsDto;
using eventsApi.Helpers;
using eventsApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace eventsApi.Controllers
{
    [ApiController]
    [Route("api/eventscollection")]
    public class EventsCollectionsController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public EventsCollectionsController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("({eventIds})", Name = "GeteventsCollection")]
        public async Task<ActionResult<IEnumerable<EventToCreateDto>>> GetEventCollection(
            [ModelBinder(BinderType = typeof(ArrayModelBinder))]
            [FromRoute] IEnumerable<Guid> eventIds
        )
        {
            var eventEntities = await _repository.Event.GetAllEventsAsync(eventIds);

            //do we have all requested authors?
            if(eventIds.Count() != eventEntities.Count())
            {
                return NotFound();
            }

            //map
            var eventsToReturn = _mapper.Map<IEnumerable<EventDto>>(eventEntities);

            return Ok(eventsToReturn);
        }


        [HttpPost]
        public async Task<ActionResult<IEnumerable<EventDto>>> CreateEventCollection(
         IEnumerable<EventToCreateDto> eventCollection
        )
        {
            var eventEntities = _mapper.Map<IEnumerable<Event>>(eventCollection);

            foreach (var evnt in eventEntities)
            {
                _repository.Event.CreateEvent(evnt);
            }
            await _repository.SaveAsync();

            var eventCollectionToReturn = _mapper.Map<IEnumerable<EventDto>>(eventEntities);

            var eventIdsAsString = string.Join(",", eventCollectionToReturn.Select(e => e.Id));

            return CreatedAtRoute("GeteventsCollection", new {eventIds = eventIdsAsString}, eventCollectionToReturn);
        }

        [HttpPost("fromcsv")]
        public async Task<ActionResult<IEnumerable<EventDtoCsv>>> CreateEventsCollectionFromCsvFile()
        {

            var myEvents = ReadCsvFile.ReadCsvFromFile();
            var eventEntities = _mapper.Map<IEnumerable<Event>>(myEvents);

            foreach (var evnt in eventEntities)
            {
                _repository.Event.CreateEvent(evnt);
            }
            await _repository.SaveAsync();

            var eventCollectionToReturn = _mapper.Map<IEnumerable<EventDtoCsv>>(eventEntities);

            var eventIdsAsString = string.Join(",", eventCollectionToReturn.Select(e => e.Id));

            return CreatedAtRoute("GeteventsCollection", new {eventIds = eventIdsAsString}, eventCollectionToReturn);
        }


    }
}