
using System.Text.Json;
using AutoMapper;
using eventsApi.Contracts;
using eventsApi.Dtos;
using eventsApi.Dtos.eventsDto;
using eventsApi.Helpers;
using eventsApi.Models;
using eventsApi.ResourceParameters;
using Microsoft.AspNetCore.Mvc;

namespace eventsApi.Controllers
{
    [ApiController]
    [Route("api/attendees")]
    public class AttendeeController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public AttendeeController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        [HttpGet(Name = "GetAttendees")]
        public async Task<IActionResult> GetAllAttendees([FromQuery] AttendeesResourceParameters attendeesResourceParameters)
        {
            try
            {
                var attendees = await _repository.Attendee.GetAllAttendeesAsync(attendeesResourceParameters);


                var previousPageLink = attendees.HasPrevious ? CreateResourceUri(attendeesResourceParameters, ResourceUriType.PreviousPage) : null;
                var nextPageLink = attendees.HasNext ? CreateResourceUri(attendeesResourceParameters, ResourceUriType.NextPage) : null;
                var paginationMetadata = new
                {
                   totalCount = attendees.TotalCount,
                   pageSize = attendees.PageSize,
                   currentPage = attendees.CurrentPage,
                   totalPages = attendees.TotalPages,
                   previousPageLink = previousPageLink,
                   nextPageLink = nextPageLink
                };

                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

                var attendeeResult = _mapper.Map<IEnumerable<AttendeeDto>>(attendees);
                return Ok(attendeeResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        private string? CreateResourceUri(
            AttendeesResourceParameters attendeesResourceParameters,
            ResourceUriType type)
        {
            switch (type)
            {
                case ResourceUriType.PreviousPage: 
                    return Url.Link("GetAttendees",
                    new
                    {
                        pageNumber = attendeesResourceParameters.PageNumber - 1,
                        pageSize = attendeesResourceParameters.PageSize,
                        name = attendeesResourceParameters.Name,
                        searchQuery = attendeesResourceParameters.SearchQuery
                    });
                case ResourceUriType.NextPage:
                    return Url.Link("GetAttendees",
                   new
                   {
                       pageNumber = attendeesResourceParameters.PageNumber + 1,
                       pageSize = attendeesResourceParameters.PageSize,
                       name = attendeesResourceParameters.Name,
                       searchQuery = attendeesResourceParameters.SearchQuery
                   });
                default:
                    return Url.Link("GetAttendees",
                 new
                 {
                     pageNumber = attendeesResourceParameters.PageNumber,
                     pageSize = attendeesResourceParameters.PageSize,
                     name = attendeesResourceParameters.Name,
                     searchQuery = attendeesResourceParameters.SearchQuery
                 });
            }
        }

        [HttpGet("{id}", Name = "AttendeeById")]
        public async Task<IActionResult> GetAttendeeById(Guid id)
        {
            try
            {
                var attendee = await _repository.Attendee.GetAttendeeByIdAsync(id);
                if (attendee == null)
                {
                    return NotFound();
                }
                else
                {
                    var attendeeResult = _mapper.Map<AttendeeDto>(attendee);
                    return Ok(attendeeResult);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error, {ex.Message}");
            }
        }

        [HttpGet("{id}/events")]
        public async Task<IActionResult> GetAllEventsForAttendee(Guid id)
        {
            try
            {
                var events = _mapper.Map<IEnumerable<EventDto>>(await _repository.Event.GetAllEventsAsync());
                var attendees = _mapper.Map<IEnumerable<AttendeeDto>>(await _repository.Attendee.GetAllAttendeesAsync());
                var attendeeEvents = await _repository.AttendeeEvent.GetAllAttendeesEvents();
                if (events == null)
                {
                    return NotFound();
                }
                else
                {
                    List<EventDto> list = new();

                    list = (
                           from attendee in attendees.Where(a => a.Id == id)
                           join attndevent in attendeeEvents on attendee.Id equals attndevent.AttendeeId
                           join evnt in events on attndevent.EventId equals evnt.Id
                           select evnt
                            ).ToList();

                    return Ok(list);
                }

            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{id}/events/{eventId}")]
        public async Task<IActionResult> GetSingleEventForAttendee(Guid id, Guid eventId)
        {
            try
            {
                var events = _mapper.Map<IEnumerable<EventDto>>(await _repository.Event.GetAllEventsAsync());
                var attendees = _mapper.Map<IEnumerable<AttendeeDto>>(await _repository.Attendee.GetAllAttendeesAsync());
                var attendeeEvents = await _repository.AttendeeEvent.GetAllAttendeesEvents();
                if (events == null)
                {
                    return NotFound();
                }
                else
                {
                    List<EventDto> list = new();

                    list = (
                           from attendee in attendees.Where(a => a.Id == id)
                           join attndevent in attendeeEvents on attendee.Id equals attndevent.AttendeeId
                           join evnt in events on attndevent.EventId equals evnt.Id
                           select evnt
                            ).ToList();

                    var eventForAttendee = list.Where(e => e.Id == eventId);

                    return Ok(eventForAttendee);
                }

            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error");
            } 
        }

        [HttpPost]
        public async Task<IActionResult> CreateAttendee([FromBody] AttendeeForCreationDto attendee, [FromQuery] Guid eventId)
        {
            try
            {
                if (attendee == null)
                {
                    return BadRequest("Attendee object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var existingAttendee = await _repository.Attendee.GetAttendeeByEmailAsync(attendee.Email);
                var attendeeEntity = _mapper.Map<Attendee>(attendee);

                if (existingAttendee != null)
                {
                    var ae = new AttendeeEvent()
                    {
                        AttendeeId = existingAttendee.Id,
                        EventId = eventId
                    };

                    _repository.AttendeeEvent.CreateAttendeeEvent(ae);
                    await _repository.SaveAsync();

                    return Ok("Event Added to your list");
                }
                else
                {
                    _repository.Attendee.CreateAttendee(attendeeEntity);
                    await _repository.SaveAsync();

                    var attendeeEventData = new AttendeeEvent()
                    {
                        AttendeeId = attendeeEntity.Id,
                        EventId = eventId
                    };

                    _repository.AttendeeEvent.CreateAttendeeEvent(attendeeEventData);
                    await _repository.SaveAsync();

                    var createdAttendee = _mapper.Map<AttendeeDto>(attendeeEntity);
                    return CreatedAtRoute("AttendeeById", new { id = createdAttendee!.Id }, createdAttendee);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error ???, {ex.InnerException}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAttendee(Guid id, [FromBody] AttendeeForUpdateDto attendee)
        {
            try
            {
                if (attendee == null)
                {
                    return BadRequest("Attendee object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var attendeeEntity = await _repository.Attendee.GetAttendeeByIdAsync(id);
                if (attendeeEntity == null)
                {
                    return NotFound();
                }

                _mapper.Map(attendee, attendeeEntity);
                _repository.Attendee.UpdateAttendee(attendeeEntity);
                await _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttendee(Guid id)
        {
            try
            {
                var attendee = await _repository.Attendee.GetAttendeeByIdAsync(id);

                if (attendee == null)
                {
                    return NotFound();
                }

                //implement a delete from a related table logic
                // if(_repository.Event.)

                _repository.Attendee.DeleteAttendee(attendee);
                await _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error");
            }
        }
    }
}