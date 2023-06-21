using System.Text.Json;
using AutoMapper;
using eventsApi.Contracts;
using eventsApi.Dtos.eventsDto;
using eventsApi.Helpers;
using eventsApi.Models;
using eventsApi.ResourceParameters;
using Microsoft.AspNetCore.Mvc;

namespace eventsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private IRepositoryWrapper _repository;

        private readonly IMapper _mapper;

        public EventsController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetEvents")]
        public async Task<IActionResult> GetAllEvents([FromQuery] EventsResourceParameters eventsResourceParameters)
        {
            try
            {
                var events = await _repository.Event.GetAllEventsAsync(eventsResourceParameters);

                var previousPageLink = events.HasPrevious ? CreateResourceUri(eventsResourceParameters, ResourceUriType.PreviousPage) : null;
                var nextPageLink = events.HasNext ? CreateResourceUri(eventsResourceParameters, ResourceUriType.NextPage) : null;
                var paginationMetadata = new
                {
                   totalCount = events.TotalCount,
                   pageSize = events.PageSize,
                   currentPage = events.CurrentPage,
                   totalPages = events.TotalPages,
                   previousPageLink = previousPageLink,
                   nextPageLink = nextPageLink
                };

                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));
                var eventsResults = _mapper.Map<IEnumerable<EventDto>>(events);
                return Ok(eventsResults);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        private string? CreateResourceUri(
            EventsResourceParameters eventsResourceParameters,
            ResourceUriType type)
        {
            switch (type)
            {
                case ResourceUriType.PreviousPage: 
                    return Url.Link("GetEvents",
                    new
                    {
                        pageNumber = eventsResourceParameters.PageNumber - 1,
                        pageSize = eventsResourceParameters.PageSize,
                        eventName = eventsResourceParameters.EventName,
                        searchQuery = eventsResourceParameters.SearchQuery
                    });
                case ResourceUriType.NextPage:
                    return Url.Link("GetEvents",
                   new
                   {
                       pageNumber = eventsResourceParameters.PageNumber + 1,
                       pageSize = eventsResourceParameters.PageSize,
                       eventName = eventsResourceParameters.EventName,
                       searchQuery = eventsResourceParameters.SearchQuery
                   });
                default:
                    return Url.Link("GetEvents",
                 new
                 {
                     pageNumber = eventsResourceParameters.PageNumber,
                     pageSize = eventsResourceParameters.PageSize,
                     eventName = eventsResourceParameters.EventName,
                     searchQuery = eventsResourceParameters.SearchQuery
                 });
            }
        }

        [HttpGet("{id}", Name = "EventById")]
        public async Task<IActionResult> GetAttendeeById(Guid id)
        {
            try
            {
                var eventReturned = await _repository.Event.GetEventByIdAsync(id);
                if (eventReturned == null)
                {
                    return NotFound();
                }
                else
                {
                    //map
                    var eventResult = _mapper.Map<EventDto>(eventReturned);
                    return Ok(eventResult);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] EventToCreateDto eventToCreateDto)
        {
            try
            {
                if (eventToCreateDto == null)
                {
                    return BadRequest("eventToCreateDto object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var eventEntity = _mapper.Map<Event>(eventToCreateDto);
                _repository.Event.CreateEvent(eventEntity);
                await _repository.SaveAsync();

                var createdEvent = _mapper.Map<CreatedEventDto>(eventEntity);
                return CreatedAtRoute("EventById", new { id = createdEvent.EventId }, createdEvent);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}