using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eventsApi.Contracts;
using eventsApi.Dtos;
using eventsApi.Dtos.eventsDto;
using eventsApi.Models;
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
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAttendees()
        {
            try
            {
                var attendees = await _repository.Attendee.GetAllAttendeesAsync();
                var attendeeResult = _mapper.Map<IEnumerable<AttendeeDto>>(attendees);
                var events = await _repository.Event.GetAllEventsAsync();
                var eventsResults = _mapper.Map<IEnumerable<EventDto>>(events);
                var aelist = await _repository.AttendeeEvent.GetAllAttendeesEvents();
                 Console.WriteLine($"the joining table {aelist.ToList()}");
                var result = from a in attendees
                             join ae in aelist on a.Id equals ae.AttendeeId
                             join e in eventsResults on ae.EventId equals e.Id
                             select new AttendeeDto 
                             {
                                Id = a.Id,
                                Email = a.Email,
                                Phone = a.Phone,
                                FirstName = a.FirstName,
                                LastName = a.LastName,
                                Speaker = a.Speaker,
                                events = new List<EventDto>() {
                                    new EventDto(){
                                        Id = e.Id,
                                        EventName = e.EventName,
                                        Location = e.Location,
                                        EventDate = e.EventDate,
                                        Description = e.Description,
                                        Capacity = e.Capacity
                                    }
                                }
                             };
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
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
                    //map
                    var attendeeResult = _mapper.Map<AttendeeDto>(attendee);

                    return Ok(attendeeResult);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error, {ex.Message}");
            }
        }

        // [HttpGet("{id}/events")]
        // public async Task<IActionResult> GetAttendeesWithDetails(int id)
        // {
        //     try
        //     {
        //         var attendee = await _repository.Attendee.GetAttendeeWithDetailsAsync(id);
        //         if (attendee == null)
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             //map
        //             return Ok(attendee);
        //         }
        //     }
        //     catch (Exception ex)
        //     {

        //         return StatusCode(500, "Internal server error");
        //     }
        // }

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

                Console.WriteLine("Creating an attendee....");

                var attendeeEntity = _mapper.Map<Attendee>(attendee);
                _repository.Attendee.CreateAttendee(attendeeEntity);
                await _repository.SaveAsync();

                var evnt = await _repository.Event.GetEventByIdAsync(eventId);

                var ae = new AttendeeEvent() 
                {
                    AttendeeId = attendeeEntity.Id, 
                    EventId = evnt.Id
                };

                _repository.AttendeeEvent.CreateAttendeeEvent(ae);
                await _repository.SaveAsync();
                
                var createdAttendee = _mapper.Map<AttendeeDto>(attendeeEntity);
                return CreatedAtRoute("AttendeeById", new { id = createdAttendee!.Id }, createdAttendee);
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