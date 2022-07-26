using Microsoft.AspNetCore.Mvc;
using System.Linq;
using FoodTrakker.Core.Model;
using FoodTrakker.Repository;
using FoodTrakker.Services;

namespace FoodTrakkerWebAplication.Controllers
{
    public class EventController : Controller
    {
        private readonly EventService _eventService;
        public EventController(EventService eventService)
        {
            _eventService = eventService;
        }
       
        // GET: EventController
        public async Task<ActionResult> Index()
        {
            var events = await _eventService.GetEventsAsync();
            var eventInNearFuture = events.OrderBy(e => e.StartDate)
                .Where(e => e.StartDate > DateTime.UtcNow)
                .Take(8).ToList();
            return View(eventInNearFuture);
        }
        // GET: EventController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var events = await _eventService.GetEventAsync(id);
            if (events != null)
            {

                return View(events);
            }

            return NotFound();
        }


    }
}
