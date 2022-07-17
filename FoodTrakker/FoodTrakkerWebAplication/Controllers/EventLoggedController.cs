
using FoodTrakker.Core.Model;
using FoodTrakker.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;


namespace FoodTrakkerWebAplication.Controllers
{
    public class EventLoggedController : Controller
    {
        private readonly IRepository<Event> _eventRepository;
        public EventLoggedController(IRepository<Event> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        // GET: EventController
        public async Task<ActionResult> Index()
        {
            var events = await _eventRepository.GetAsync();
            return View(events);
        }

        // GET: EventController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var events = await _eventRepository.GetAsync();
            return View(events.SingleOrDefault(e => e.Id == id));
        }

        // GET: EventController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Event eventToCreate)
        {
            var events = await _eventRepository.GetAsync();
            if (!ModelState.IsValid)
            {
                return View(eventToCreate);
            }
            try
            {
                events.Add(eventToCreate);
            }
            catch
            {
                return View();
            }
            return RedirectToAction("Index");
        }

        // GET: EventController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var events = await _eventRepository.GetAsync();
            return View(events.FirstOrDefault(e => e.Id == id));
        }

        // POST: EventController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Event eventToEdit)
        {
            var events = await _eventRepository.GetAsync();
            if (!ModelState.IsValid)
            {
                return View(events);
            }
            try
            {
                var existingEvent = events.FirstOrDefault(e => e.Id == id);

                existingEvent.Name = eventToEdit.Name;
                existingEvent.Description = eventToEdit.Description;
                existingEvent.StartDate = eventToEdit.StartDate;
                existingEvent.EndDate = eventToEdit.EndDate;
                // existingEvent.FoodTrucks = eventToEdit.FoodTrucks;
                existingEvent.Location = eventToEdit.Location;

                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }

        }

        // GET: EventController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var events = await _eventRepository.GetAsync();
            return View(events.FirstOrDefault(e => e.Id == id));
        }

        // POST: EventController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Event @event)
        {
            var events = await _eventRepository.GetAsync();
            try
            {
                var eventToDelete = events.FirstOrDefault(e => e.Id == id);
                events.Remove(eventToDelete);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}