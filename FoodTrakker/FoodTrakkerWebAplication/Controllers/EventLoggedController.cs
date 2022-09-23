
using AutoMapper;
using FoodTrakker.Core.Model;
using FoodTrakker.Repository;
using FoodTrakker.Services;
using FoodTrakker.Services.DTOs;
using Microsoft.AspNetCore.Mvc;


namespace FoodTrakkerWebAplication.Controllers
{
    public class EventLoggedController : Controller
    {
        private readonly EventService _eventService;
        private readonly IMapper _mapper;
        public EventLoggedController(EventService eventService,IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;
        }

        // GET: EventController
        public async Task<ActionResult> Index(string searchEventByName)
        {
            var searchedEvents = new List<Event>();
            if (!String.IsNullOrEmpty(searchEventByName))
            {
                searchedEvents = await _eventService.FindEventAsync(searchEventByName);
                var searchedEventsDto = _mapper.Map<ICollection<Event>,
                    ICollection<Event>>(searchedEvents); ;
                return View((IEnumerable<EventDto>)searchedEventsDto);
            }
            //else
            //{
            //    searchedEvents = (List<Event>)await _eventService.GetFullEventInfoAsync();
            //}

            var events = await _eventService.GetEventsAsync();
            var eventsDto = _mapper.Map<ICollection<Event>, ICollection<EventDto>>(events);
            return View(eventsDto);
        }

        // GET: EventController/Details/5
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

        // GET: EventController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EventDto eventToCreate)
        {
            var events = await _eventService.GetEventsAsync();
            var eventsDto = _mapper.Map<ICollection<Event>, ICollection<EventDto>>(events);
            if (!ModelState.IsValid)
            {
                return View(eventToCreate);
            }
            try
            {
                eventsDto.Add(eventToCreate);
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
            var eventDtoById = _mapper.Map<Event, EventDto>(eventById);
            if (eventDtoById != null)
            {

                return View(eventDtoById);
            }

            return NotFound();
        }

        // POST: EventController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Event eventToEdit)
        {
            var events = await _eventService.GetEventsAsync();
            var eventsDto = _mapper.Map<ICollection<Event>, ICollection<EventDto>>(events);
            if (!ModelState.IsValid)
            {
                return View(eventsDto);
            }
            try
            {
                var existingEvent = eventsDto.SingleOrDefault(e => e.Id == id);

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
            var eventDtoToDelete = _mapper.Map<Event, EventDto>(eventToDelte);
            if (eventDtoToDelete != null)
            {

                return View(eventDtoToDelete);
            }

            return NotFound();
        }

        // POST: EventController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Event @event)
        {
            var events = await _eventService.GetEventsAsync();
            var eventsDto = _mapper.Map<ICollection<Event>, ICollection<EventDto>>(events);
            try
            {
                var eventToDelete = eventsDto.SingleOrDefault(e => e.Id == id);
                eventsDto.Remove(eventToDelete);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}