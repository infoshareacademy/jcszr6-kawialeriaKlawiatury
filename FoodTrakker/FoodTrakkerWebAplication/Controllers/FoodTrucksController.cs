using AutoMapper;
using FoodTrakker.Core.Model;
using Microsoft.AspNetCore.Mvc;
using FoodTrakker.Services;
using FoodTrakker.Repository;
using FoodTrakker.Services.DTOs;

namespace FoodTrakkerWebAplication.Controllers
{
    public class FoodTrucksController : Controller
    {
        private readonly FoodTruckService _foodTruckService;
        private readonly IMapper _mapper;

        public FoodTrucksController(FoodTruckService foodTruckService, IMapper mapper)
        {
            _foodTruckService = foodTruckService;
            _mapper = mapper;
        }
        
        public async Task<ActionResult> Index()
        {
            var foodTrucks = await _foodTruckService.GetFullFoodTruckInfoAsync();
            var foodTruckDto = _mapper.Map<ICollection<FoodTruck>, ICollection<FoodTruckDto>>(foodTrucks);
            return View(foodTruckDto);
        }

        //GET: FoodTrucksController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var foodTruck = await _foodTruckService.GetFullFoodTruckInfoAsync(id);
            var foodTruckDto = _mapper.Map<ICollection<FoodTruck>, ICollection<FoodTruckDto>>(foodTruck);
            if (foodTruck != null)
            {

                return View(foodTruckDto);
            }

            return NotFound();
        }

    }
}
