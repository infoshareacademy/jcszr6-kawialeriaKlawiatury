using AutoMapper;
using FoodTrakker.Api.Models;
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
        private readonly IMapper _mapper;

        public EventController(EventService eventService, IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;
        }

        // GET: api/<EventController>
        [HttpGet]
        public async Task<ICollection<EventApiGet>> Get()
        {
            var events = await _eventService.GetEventsAsync();
            var eventsApiGet = _mapper.Map<ICollection<Event>, ICollection<EventApiGet>>(events);
            return eventsApiGet;
        }

        // GET api/<EventController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventApiGet?>> GetEventById(int id)
        {
            var eventById = await _eventService.GetEventAsync(id);
            var eventByIdApiGet = _mapper.Map<EventApiGet>(eventById);

            if (eventById is null)
            {
                return NotFound();
            }

            return eventByIdApiGet;
        }

        // POST api/<EventController>
        [HttpPost]
        public async Task<EventApiGet> CreateEvent(EventApiPost eventDto)
        {
            var @event = _mapper.Map<Event>(eventDto);
            var eventWithId = await _eventService.AddEventAsyncWithReturn(@event);

            return _mapper.Map<EventApiGet>(eventWithId);
        }

        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Event>> UpdateEvent([FromRoute] int id, EventApiPost eventApiPost)
        {
            var eventToUpdate = await _eventService.GetEventAsync(id);
            if (eventToUpdate is null)
                return BadRequest();

            eventToUpdate.Name = eventApiPost.Name;
            eventToUpdate.Description = eventApiPost.Description;
            eventToUpdate.Location = eventApiPost.Location;
            eventToUpdate.StartDate = eventApiPost.StartDate;
            eventToUpdate.EndDate = eventApiPost.EndDate;

            //var eventUpdateGet = _mapper.Map<EventApiGet>(eventApiPost);
            //eventUpdateGet.Id = id;
            //var eventToUpdate = _mapper.Map<Event>(eventUpdateGet);
            await _eventService.UpdateEvent(eventToUpdate);

            return Ok();
        }

        // DELETE api/<EventController>/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _eventService.DeleteEvent(id);
            return Ok();
        }
    }
}