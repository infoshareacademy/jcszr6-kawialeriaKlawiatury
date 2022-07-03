using FoodTrakkerWebAplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using FoodTrakker_WebBusinessLogic;
using FoodTrakker_WebBusinessLogic.Model;


namespace FoodTrakkerWebAplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<Event> _eventRepository;
        private readonly IRepository<FoodTruck> _foodTruckRepository;

        public HomeController(ILogger<HomeController> logger, IRepository<Event> eventRepository, IRepository<FoodTruck> foodTruckRepository)
        {
            _logger = logger;
            _eventRepository = eventRepository;
            _foodTruckRepository = foodTruckRepository;
        }

        public async Task<IActionResult> Index()
        {
            var foodTrucks = await _foodTruckRepository.GetAsync();
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