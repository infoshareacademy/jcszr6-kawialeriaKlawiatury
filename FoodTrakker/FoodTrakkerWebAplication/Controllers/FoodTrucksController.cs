using Microsoft.AspNetCore.Mvc;
using FoodTrakker.Services;

namespace FoodTrakkerWebAplication.Controllers
{
    public class FoodTrucksController : Controller
    {
        private readonly FoodTruckService _foodTruckService;
        private readonly ReviewService _reviewService;

        public FoodTrucksController(FoodTruckService foodTruckService, ReviewService reviewService)
        {
            _foodTruckService = foodTruckService;
            _reviewService = reviewService;
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
            var foodTruck = await _foodTruckService.GetFoodTruckAsync(id);
            foodTruck.Reviews = await _reviewService.GetFoodTruckReviewsAsync(id);
            if (foodTruck != null)
            {

                return View(foodTruck);
            }

            return NotFound();




            //public IActionResult Index()
            //{
            //    return View();
            //}
        }

    }
}
