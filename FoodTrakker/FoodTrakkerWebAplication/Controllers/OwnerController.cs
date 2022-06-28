using FoodTrakker.BusinessLogic.Models;
using FoodTrakker.BusinessLogic.Repository;
using FoodTrakkerWebAplication.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodTrakkerWebAplication.Controllers
{
    public class OwnerController : Controller
    {
        private readonly IRepository<Event> _eventRepository;

        public OwnerController(IRepository<Event> eventRepository)
        {
            _eventRepository = eventRepository;
        }
        // GET: OwnerController
        public async Task<ActionResult> Index()
        {
            var events = await _eventRepository.GetAsync();
            var foodTrucks = events.SelectMany(e => e.FoodTrucks).ToList();
            var uEViewModel = new FoodTruckEventViewModel();
            uEViewModel.Events = events;
            uEViewModel.Foodtrucks = foodTrucks;
            return View(uEViewModel);
        }

        // GET: OwnerController/Details/5
        public async Task<ActionResult> DetailsFoodTruck(int id)
        {
            var events = await _eventRepository.GetAsync();
            var foodTruck = events.SelectMany(e => e.FoodTrucks).FirstOrDefault(f => f.Id == id);

            if (foodTruck != null)
            {
                
                return View(foodTruck);
            }

            return NotFound();
        }

        // GET: OwnerController/Details/5
        public async Task<ActionResult> DetailsEvent(int id)
        {
            var events = await _eventRepository.GetAsync();
            var chosenEvent = events.FirstOrDefault(e => e.Id == id);

            if (chosenEvent != null)
            {

                return View(chosenEvent);
            }

            return NotFound();
        }

        // GET: OwnerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OwnerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OwnerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OwnerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OwnerController/Delete/5
        public async Task<ActionResult>  DeleteFoodTruck(int id)
        {
            var events = await _eventRepository.GetAsync();
            var foodTruckToDelete = events.SelectMany(e => e.FoodTrucks).FirstOrDefault(f => f.Id == id);
            return View(foodTruckToDelete);
        }

        // POST: OwnerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteFoodTruck(int id, FoodTruck foodTruck)
        {
            var events = await _eventRepository.GetAsync();
            var foodTrucks = events.SelectMany(e => e.FoodTrucks).ToList();
            var foodTruckToDelete = foodTrucks.SingleOrDefault(f => f.Id == id);
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(foodTruck);
            }
        }
        // GET: OwnerController/Delete/5
        public async Task<ActionResult> DeleteEvent(int id)
        {
            var events = await _eventRepository.GetAsync();

            return View(events.SingleOrDefault(e => e.Id == id));
        }

        // POST: OwnerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteEvent(int id, Event eventToDelete)
        {
            var events = await _eventRepository.GetAsync();
            try
            {
                _eventRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(eventToDelete);
            }
        }
    }
}
