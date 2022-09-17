using FoodTrakker.Core.Model;
using FoodTrakker.Services;
using FoodTrakker.Services.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FoodTrakker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly EventService _eventService;
        public EventController(EventService eventService)
        {
            _eventService = eventService;
        }
        // GET: api/<EventController>
        [HttpGet]
        public IActionResult Get() => Ok(_eventService.GetEventsAsync());

        // GET api/<EventController>/5
        [HttpGet("{id}")]
        public ActionResult<Event> GetEventById(int id)
        {
            var eventById = _eventService.GetEventAsync(id);

            if (eventById is null)
            {
                return NotFound();
            }

            return Ok(eventById);
        }

        // POST api/<EventController>
        [HttpPost]
        public IActionResult CreateEvent(Event eventToCreate)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            var events = _eventService.GetEventsAsync();

            events.Result.Add(new Event
            {
                Location = eventToCreate.Location,
                Name = eventToCreate.Name,
                StartDate = eventToCreate.StartDate,
                EndDate = eventToCreate.EndDate,
                Description = eventToCreate.Description
            });

            return Ok();
        }
    

        // PUT api/<EventController>/5
    [HttpPut("{id}")]
   
    public ActionResult<Event> UpdateEvent(Event eventUpdate)
    {
            var events = _eventService.GetEventsAsync();
            var eventToUpdate = events.Result.SingleOrDefault(e => e.Id == eventUpdate.Id);

            eventToUpdate.Name = eventUpdate.Name;
            eventToUpdate.Description = eventUpdate.Description;
            eventToUpdate.StartDate = eventUpdate.StartDate;
            eventToUpdate.EndDate = eventUpdate.EndDate;
            eventToUpdate.Location = eventUpdate.Location;

            if (eventToUpdate is null)
        {
            return NotFound();
        }
        
        

        return Ok(eventToUpdate);
    }

    // DELETE api/<EventController>/5
    [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var events = _eventService.GetEventsAsync();
            var eventToDelete = events.Result.SingleOrDefault(e => e.Id == id);

            if (eventToDelete == null)
            {
                return NotFound();
            }

            events.Result.Remove(eventToDelete);

            return Ok(eventToDelete);
        }

    }
}
