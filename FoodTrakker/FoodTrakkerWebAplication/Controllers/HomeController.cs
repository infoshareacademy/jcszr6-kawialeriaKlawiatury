using FoodTrakkerWebAplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using FoodTrakker.BusinessLogic.Models;
using FoodTrakker.BusinessLogic.Repository;


namespace FoodTrakkerWebAplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<Event> _eventRepository;
 

        public HomeController(ILogger<HomeController> logger, IRepository<Event> eventRepository)
        {
            _logger = logger;
            _eventRepository = eventRepository;

        }

        public async Task<IActionResult> Index()
        {
            var events = await _eventRepository.GetAsync();
            return View(events.SelectMany(e => e.FoodTrucks));
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