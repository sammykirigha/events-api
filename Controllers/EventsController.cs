using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eventsApi.Contracts;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace eventsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private IRepositoryWrapper _repository;

        public EventsController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            var events = _repository.Event.FindAll();

            return (IEnumerable<string>)Ok(events);
            // return new Any[] { "value1", "value2", events };
        }
    }
}