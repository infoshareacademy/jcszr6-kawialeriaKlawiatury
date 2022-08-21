using FoodTrakker.Core;
using FoodTrakker.Repository;
using FoodTrakker.Services;
using FoodTrakkerWebAplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using FoodTrakker.Core.Model;


namespace FoodTrakkerWebAplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FoodTruckService _foodTruckService;
        //private readonly IRepository<Event> _eventRepository;
        //private readonly IRepository<FoodTruck> _foodTruckRepository;


        public HomeController(ILogger<HomeController> logger,FoodTruckService foodTruckService )
        {
            _logger = logger;
            _foodTruckService = foodTruckService;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var foodTrucks = new List<FoodTruck>();
            if (!String.IsNullOrEmpty(searchString))
            {
                foodTrucks = await _foodTruckService.FindFoodTruckAsync(searchString);
            }
            else
            {
                foodTrucks = await _foodTruckService.GetFoodTrucksAsync();
            }

            //var foodTrucks = await _foodTruckService.GetFoodTrucksAsync();
            //if (foodTrucks == null)
            //{
            //    return NotFound();
            //}
            return View(foodTrucks);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}