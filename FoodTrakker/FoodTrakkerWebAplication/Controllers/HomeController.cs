using FoodTrakker.Core;
using FoodTrakker.Repository;
using FoodTrakker.Services;
using FoodTrakkerWebAplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;



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

        public async Task<IActionResult> Index()
        {
            var foodTrucks = await _foodTruckService.GetFoodTrucksAsync();
            if(foodTrucks == null)
            {
                return NotFound();
            }
            return View(foodTrucks);
        }

        public IActionResult Privacy()
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