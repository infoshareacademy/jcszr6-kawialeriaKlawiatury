
using FoodTrakker.Core.Model;
using FoodTrakker.Repository;
using FoodTrakker.Services;
using Microsoft.AspNetCore.Mvc;


namespace FoodTrakkerWebAplication.Controllers
{
    public class EventLoggedController : Controller
    {
        private readonly EventService _eventService;
        public EventLoggedController(EventService eventService)
        {
            _eventService = eventService;
        }

        // GET: EventController
        public async Task<ActionResult> Index()
        {
            var events = await _eventService.GetEventsAsync();
            return View(events);
        }

        // GET: EventController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var eventById = await _eventService.GetEventAsync(id);
            if (eventById != null)
            {

                return View(eventById);
            }

            return NotFound();
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
            var events = await _eventService.GetEventsAsync();
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
            var eventById = await _eventService.GetEventAsync(id);
            if (eventById != null)
            {

                return View(eventById);
            }

            return NotFound();
        }

        // POST: EventController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Event eventToEdit)
        {
            var events = await _eventService.GetEventsAsync();
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
            var eventToDelte = await _eventService.GetEventAsync(id);
            if (eventToDelte != null)
            {

                return View(eventToDelte);
            }

            return NotFound();
        }

        // POST: EventController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Event @event)
        {
            var events = await _eventService.GetEventsAsync();
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