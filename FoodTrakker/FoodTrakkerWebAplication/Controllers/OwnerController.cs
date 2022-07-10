
using FoodTrakker.Core.Model;
using FoodTrakker.Repository;
using FoodTrakkerWebAplication.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;

namespace FoodTrakkerWebAplication.Controllers
{
    public class OwnerController : Controller
    {
        private readonly IRepository<Event> _eventRepository;
        private readonly IRepository<FoodTruck> _foodTruckRepository;
        public OwnerController(IRepository<Event> eventRepository, IRepository<FoodTruck> foodRepository)
        {
            _eventRepository = eventRepository;
            _foodTruckRepository = foodRepository;
        }
        // GET: OwnerController
        public async Task<ActionResult> Index()
        {
            throw new NotImplementedException();
        }

        // GET: OwnerController/Details/5
        public async Task<ActionResult> DetailsFoodTruck(int id)
        {
            var foodTruck = await _foodTruckRepository.GetAsync(id);

            if (foodTruck != null)
            {

                return View(foodTruck);
            }

            return NotFound();
        }

        // GET: OwnerController/Details/5
        public async Task<ActionResult> DetailsEvent(int id)
        {
            var events = await _eventRepository.GetAsync(id);

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
            var foodTrucks = await _foodTruckRepository.GetAsync();
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
            var foodTruckToEdit = await _foodTruckRepository.GetAsync(id);
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
            var foodTruckToEdit = await _foodTruckRepository.GetAsync(id);
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
            var foodTruckToDelete = await _foodTruckRepository.GetAsync(id);
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
            var events = await _eventRepository.GetAsync(id);

            return View(events);
        }

        // POST: OwnerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteEvent(int id, Event eventToDelete)
        {
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
