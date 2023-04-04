using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eventsApi.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace eventsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendeeController : ControllerBase
    {
        private IRepositoryWrapper _repository;

        public AttendeeController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOwners()
        {
            try
            {
                var attendees = await _repository.Attendee.GetAllAttendeesAsync();

                return Ok(attendees);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error");
            }
        }
    }
}