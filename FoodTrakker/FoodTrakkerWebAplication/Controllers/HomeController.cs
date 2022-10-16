using FoodTrakker.Core;
using FoodTrakker.Repository;
using FoodTrakker.Services;
using FoodTrakkerWebAplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using FoodTrakker.Core.Model;
using AutoMapper;
using FoodTrakker.Services.DTOs;

namespace FoodTrakkerWebAplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FoodTruckService _foodTruckService;
        private readonly TypeService _typeService;
        private readonly IMapper _mapper;
        //private readonly IRepository<Event> _eventRepository;
        //private readonly IRepository<FoodTruck> _foodTruckRepository;


        public HomeController(ILogger<HomeController> logger,
            FoodTruckService foodTruckService,
            TypeService typeService,
            IMapper mapper)
        {
            _logger = logger;
            _foodTruckService = foodTruckService;
            _mapper = mapper;
            _typeService = typeService;
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
                foodTrucks = await _foodTruckService.GetRandomFoodTrucks(6);
            }


            ViewBag.Types = await _typeService.GetRandomTypesAsync(4);
            var foodTruckDtos = _mapper.Map<List<FoodTruck>, List<FoodTruckDto>>(foodTrucks);

            return View(foodTruckDtos);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Error500()
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