using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eventsApi.Contracts;
using eventsApi.Dtos;
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

                //map
                return Ok(attendees);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error");
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
                    return Ok(attendee);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/events")]
        public async Task<IActionResult> GetAttendeesWithDetails(Guid id)
        {
            try
            {
                var attendee = await _repository.Attendee.GetAttendeeWithDetailsAsync(id);
                if (attendee == null)
                {
                    return NotFound();
                }
                else
                {
                    //map
                    return Ok(attendee);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAttendee([FromBody] AttendeeForCreationDto attendee)
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

                return CreatedAtRoute("AttendeeById", new { id = createdAttendee.AttendeeId }, createdAttendee);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}