
using FoodTrakker.Core.Model;
using FoodTrakker.Repository;
using FoodTrakker.Services;
using FoodTrakkerWebAplication.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;

namespace FoodTrakkerWebAplication.Controllers
{
    public class OwnerController : Controller
    {
        private readonly FoodTruckService _foodTruckService;
        private readonly EventService _eventService;
        public OwnerController(EventService eventService, FoodTruckService foodTruckService)
        {
            _eventService = eventService;
            _foodTruckService = foodTruckService;
        }
        // GET: OwnerController
        public async Task<ActionResult> Index()
        {
            var events = await _eventService.GetEventsAsync();
            var foodTrucks = await _foodTruckService.GetFullFoodTruckInfoAsync();
            var uEViewModel = new FoodTruckEventViewModel();
            uEViewModel.Events = events;
            uEViewModel.Foodtrucks = foodTrucks;
            return View(uEViewModel);
        }

        // GET: OwnerController/Details/5
        public async Task<ActionResult> DetailsFoodTruck(int id)
        {
            var foodTruck = await _foodTruckService.GetFullFoodTruckInfoAsync(id);

            if (foodTruck != null)
            {
                return View(foodTruck);
            }

            return NotFound();
        }

        // GET: OwnerController/Details/5
        public async Task<ActionResult> DetailsEvent(int id)
        {
            var events = await _eventService.GetFullEventInfoAsync(id);

            if (events != null)
            {

                return View(events);
            }

            return NotFound();
        }

        // GET: OwnerController/Create
        public ActionResult CreateFoodTruck()
        {
            return View();
        }

        // POST: OwnerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateFoodTruck(FoodTruck foodTruck)
        {
            var foodTrucks = await _foodTruckService.GetFoodTrucksAsync();
            var index = foodTrucks.OrderBy(f => f.Id).Last().Id;
            foodTruck.Id = index + 1;
            foodTruck.OwnerId = 1; //Temporary value to be updated!!!
            if (!ModelState.IsValid)
            {
                return View(foodTruck);
            }

            try
            {

                foodTrucks.Add(foodTruck);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OwnerController/Edit/5
        public async Task<ActionResult> EditFoodTruck(int id)
        {
            var foodTruckToEdit = await _foodTruckService.GetFoodTruckAsync(id);
            return View(foodTruckToEdit);
        }

        // POST: OwnerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditFoodTruck(int id, FoodTruck foodTruck)
        {
            if (!ModelState.IsValid)
            {
                return View(foodTruck);
            }
            var foodTruckToEdit = await _foodTruckService.GetFoodTruckAsync(id);
            try
            {
                foodTruckToEdit.Name = foodTruck.Name;
                foodTruckToEdit.Description = foodTruck.Description;
                foodTruckToEdit.Type.Name = foodTruck.Type.Name;
                foodTruckToEdit.Location.City = foodTruck.Location.City;
                foodTruckToEdit.Location.Street = foodTruck.Location.Street;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OwnerController/Delete/5
        public async Task<ActionResult> DeleteFoodTruck(int id)
        {
            var foodTruckToDelete = await _foodTruckService.GetFoodTruckAsync(id);
            return View(foodTruckToDelete);
        }

        // POST: OwnerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteFoodTruck(int id, FoodTruck foodTruck)
        {
            throw new NotImplementedException();
        }
        //GET: OwnerController/Delete/5
        public async Task<ActionResult> DeleteEvent(int id)
        {
            var events = await _eventService.GetEventAsync(id);

            return View(events);
        }

        // POST: OwnerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteEvent(int id, Event eventToDelete)
        {
            try
            {
                _eventService.GetEventAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(eventToDelete);
            }
        }
    }

}
