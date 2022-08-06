using FoodTrakker.Core.Model;
using Microsoft.AspNetCore.Mvc;
using FoodTrakker.Services;
using FoodTrakker.Repository;

namespace FoodTrakkerWebAplication.Controllers
{
    public class FoodTrucksController : Controller
    {
        private readonly FoodTruckService _foodTruckService;

        public FoodTrucksController(FoodTruckService foodTruckService)
        {
            _foodTruckService = foodTruckService;
        }

        public async Task<ActionResult> Index()
        {
           var foodTrucks = await _foodTruckService.GetFullFoodTruckInfoAsync();
            var foodTruck = foodTrucks.OrderBy(ft => ft.Name).ToList();
            return View(foodTrucks);
        }

        //GET: FoodTrucksController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var foodTrucks = await _foodTruckService.GetFullFoodTruckInfoAsync(id);
            if (foodTrucks != null)
            {

                return View(foodTrucks);
            }

            return NotFound();
        }

    }
}
