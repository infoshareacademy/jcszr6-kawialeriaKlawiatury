using Microsoft.AspNetCore.Mvc;
using System.Linq;
using FoodTrakker_WebBusinessLogic.Model;
using FoodTrakker_WebBusinessLogic;

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
        public async Task <ActionResult> Index()
        {
            var events = await _eventRepository.GetAsync();
            var eventInNearFuture = events.OrderBy(e => e.StartDate).Take(1).ToList();
            return View(events);
        }


    }
}
