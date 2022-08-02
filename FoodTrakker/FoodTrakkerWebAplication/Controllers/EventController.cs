using Microsoft.AspNetCore.Mvc;
using System.Linq;
using FoodTrakker.Core.Model;
using FoodTrakker.Repository;
using FoodTrakker.Services;
using AutoMapper;
using FoodTrakker.Services.DTOs;

namespace FoodTrakkerWebAplication.Controllers
{
    public class EventController : Controller
    {
        private readonly EventService _eventService;
        private readonly IMapper _mapper;
        public EventController(EventService eventService, IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;
        }
       
        // GET: EventController
        public async Task<ActionResult> Index()
        {
            var events = await _eventService.GetEventsAsync();
            var eventInNearFuture = events.OrderBy(e => e.StartDate)
                .Where(e => e.StartDate > DateTime.UtcNow)
                .Take(8).ToList();
            var eventDtoInNearFuture = _mapper.Map<List<Event>,List<EventDto>>(eventInNearFuture);
            return View(eventDtoInNearFuture);
        }
       
        // GET: OwnerController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var events = await _eventService.GetFullEventInfoAsync(id);
            var eventsDto = _mapper.Map<Event, EventDto>(events);
            if (eventsDto != null)
            {

                return View(eventsDto);
            }

            return NotFound();
        }

    }
}
