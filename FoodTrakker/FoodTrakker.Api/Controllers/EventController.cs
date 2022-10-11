using FoodTrakker.Core.Model;
using FoodTrakker.Services;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<Event?> GetEventById(int id)
        {
            var eventById = await _eventService.GetEventAsync(id);

            if (eventById is null)
            {
                throw new NullReferenceException();
            }

            return eventById;
        }

        // POST api/<EventController>
        [HttpPost]
        public Task<Event> CreateEvent(int id)
        {
            var eventToAdd = _eventService.GetEventAsync(id);
            var events = _eventService.GetEventsAsync();
            events.Result.Add(new Event
            {
                Name = eventToAdd.Result.Name,
                Description = eventToAdd.Result.Description,
                StartDate = eventToAdd.Result.StartDate,
                EndDate = eventToAdd.Result.EndDate
            });

            return Task.FromResult(eventToAdd.Result);
        }

        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public Task<Event> UpdateEvent(Event eventUpdate)
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
                throw new ArgumentNullException(nameof(eventToUpdate));
            }

            return Task.FromResult(eventToUpdate);
        }

        // DELETE api/<EventController>/5
        [HttpDelete("{id:int}")]
        public Task Delete(int id)
        {
            var events = _eventService.GetEventsAsync();
            var eventToDelete = events.Result.SingleOrDefault(e => e.Id == id);

            if (eventToDelete == null)
            {
                throw new NullReferenceException();
            }

            events.Result.Remove(eventToDelete);

            return Task.CompletedTask;
        }
    }
}