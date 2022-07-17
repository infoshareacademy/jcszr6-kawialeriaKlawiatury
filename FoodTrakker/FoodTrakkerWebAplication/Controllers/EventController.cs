using Microsoft.AspNetCore.Mvc;
using System.Linq;
using FoodTrakker.Core.Model;
using FoodTrakker.Repository;


namespace FoodTrakkerWebAplication.Controllers
{
    public class EventController : Controller
    {

        private readonly IRepository<Event> _eventRepository;
        public EventController(IRepository<Event> eventRepository)
        {
            _eventRepository = eventRepository;
        }
        // GET: EventController
        public async Task<ActionResult> Index()
        {
            var events = await _eventRepository.GetAsync();
            var eventInNearFuture = events.OrderBy(e => e.StartDate)
                .Where(e => e.StartDate > DateTime.UtcNow)
                .Take(8).ToList();
            return View(eventInNearFuture);
        }
        // GET: EventController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var events = await _eventRepository.GetAsync();
            return View(events.SingleOrDefault(e => e.Id == id));
        }


    }
}
