using AutoMapper;
using FoodTrakker.Api.Models;
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
        private readonly IMapper _mapper;
        public EventController(EventService eventService, IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;
        }
        // GET: api/<EventController>
        [HttpGet]
        public IActionResult Get() => Ok(_eventService.GetEventsAsync());
        //public Task<ICollection<Event>> Get()
        //{
        //    return _eventService.GetEventsAsync();
        //}
        // GET api/<EventController>/5
        [HttpGet("{id}")]
        public Task<Event?> GetEventById(int id)
        {
            var eventById = _eventService.GetEventAsync(id);

            if (eventById is null)
            {
                throw new NullReferenceException();
            }

            return Task.FromResult<Event?>(eventById.Result);
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

        public async Task<ActionResult<Event>> UpdateEvent([FromRoute]int id,EventApiPost eventApiPost)
        {
           
            var eventUpdateGet = _mapper.Map<EventApiGet>(eventApiPost);
            eventUpdateGet.Id = id;
            var eventToUpdate = _mapper.Map<Event>(eventUpdateGet);
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
