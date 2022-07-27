using Microsoft.AspNetCore.Mvc;
using FoodTrakker.Services;

namespace FoodTrakkerWebAplication.Controllers
{
    public class FoodTrucksController : Controller
    {
        private readonly FoodTruckService _foodTruckService;

        public FoodTrucksController(FoodTruckService foodTruckService)
        {
            _foodTruckService = foodTruckService;
        }

        // GET: FoodTrucksController
        public async Task<ActionResult> Index()
        {
            var foodTrucks = await _foodTruckService.GetFoodTrucksAsync();
            var foodTruck = foodTrucks.OrderBy(ft => ft.Name).ToList();
            return View(foodTrucks);
        }

        //GET: FoodTrucksController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var foodTrucks = await _foodTruckService.GetFoodTruckAsync(id);
            if (foodTrucks != null)
            {

                return View(foodTrucks);
            }

            return NotFound();




            //public IActionResult Index()
            //{
            //    return View();
            //}
        }

    }
}
