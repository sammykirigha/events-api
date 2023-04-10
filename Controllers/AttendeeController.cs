using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eventsApi.Contracts;
using eventsApi.Dtos;
using eventsApi.Entities.Models;
using eventsApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace eventsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        public async Task<IActionResult> GetAllOwners()
        {
            try
            {
                var attendees = await _repository.Attendee.GetAllAttendeesAsync();

                var attendeeResult = _mapper.Map<IEnumerable<AttendeeDto>>(attendees);
                return Ok(attendeeResult);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}", Name = "AttendeeById")]
        public async Task<IActionResult> GetAttendeeById(int id)
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

                return StatusCode(500, "Internal server error");
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

        [HttpPost("create/{id}")]
        public async Task<IActionResult> CreateAttendee(int eventId, [FromBody] AttendeeForCreationDto attendee)
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

                var attendeeEntity = _mapper.Map<Attendee>(attendee);
                _repository.Attendee.CreateAttendee(attendeeEntity);
                await _repository.SaveAsync();
                var createdAttendee = _mapper.Map<AttendeeDto>(attendeeEntity);

                var eventReturned = await _repository.Event.GetEventByIdAsync(eventId);
                eventReturned?.Attendees?.Add(attendeeEntity);
                await _repository.SaveAsync();
                // if (createdAttendee != null && eventReturned != null)
                // {

                //     var newAttendeeEvent = new EventAttendee
                //     {
                //         AttendeesAttendeeId = createdAttendee.AttendeeId,
                //         EventsEventId = 
                //     };
                //     _repository.EventAttendee.CreateEventAttendee(newAttendeeEvent);
                // }


                return CreatedAtRoute("AttendeeById", new { id = createdAttendee!.AttendeeId }, createdAttendee);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error ???, {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAttendee(int id, [FromBody] AttendeeForUpdateDto attendee)
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
        public async Task<IActionResult> DeleteAttendee(int id)
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