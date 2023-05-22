using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eventsApi.Contracts;
using eventsApi.Dtos.eventsDto;
using eventsApi.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        [HttpGet]
        public async Task<IActionResult> GetAllEvents(string? eventName = "", string? searchQuery = "")
        {
            try
            {
                var events = await _repository.Event.GetAllEventsAsync(eventName, searchQuery);
                var eventsResults = _mapper.Map<IEnumerable<EventDto>>(events);
                return Ok(eventsResults);
            }
            catch (System.Exception)
            {
                throw;
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