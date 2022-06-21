using FoodTrakkerWebAplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using FoodTrakker.BusinessLogic.Models;
using FoodTrakker.BusinessLogic.Repository;
using FoodTrakkerWebAplication.Contracts;

namespace FoodTrakkerWebAplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGetable _getter;
        private static List<FoodTruck> _foodTrucks = DataRepository<FoodTruck>.GetData();
        public HomeController(ILogger<HomeController> logger, IGetable getter)
        {
            _logger = logger;
            _getter = getter;
        }

        public IActionResult Index()
        {
            return View(_foodTrucks);
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