using AutoMapper;
using FoodTrakker.Core.Model;
using Microsoft.AspNetCore.Mvc;
using FoodTrakker.Services;
using FoodTrakker.Repository;
using FoodTrakker.Services.DTOs;
using FoodTrakkerWebAplication.Models.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
        
        public async Task<ActionResult> Index(string type, string searchString, string citySearchString, string streetSearchString)
        {
            //IQueryable<string> typeQuery = from f in (_foodTruckService.FindByType(type)) orderby f.Type
                                                select f.Type;
                //await _foodTruckService.FindByTypeAsync(fooodTruckType);
            var foodTrucks = new List<FoodTruck>();
            if (!String.IsNullOrEmpty(searchString))
            {
                foodTrucks = await _foodTruckService.FindFoodTruckAsync(searchString);
            }
            else if (!String.IsNullOrEmpty(citySearchString))
            {
                foodTrucks = await _foodTruckService.FindByCityAsync(citySearchString);
            }
            else if (!String.IsNullOrEmpty(streetSearchString))
            {
                foodTrucks = await _foodTruckService.FindByStreetAsync(streetSearchString);
            }
            else
            {
                foodTrucks = await _foodTruckService.GetFullFoodTruckInfoAsync();
            }

            var foodTruckTypeVM = new FoodTruckTypesViewModel()
            {
                Types = new SelectList(await typeQuery.Distinct().ToListAsync()),
                FoodTrucks = await.foodTrucks.ToListAsync()
            };
            
            var foodTruckDto = _mapper.Map<ICollection<FoodTruck>, 
                ICollection<FoodTruckDto>>(foodTrucks);
            return View(foodTruckDto);
        }

        //GET: FoodTrucksController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var foodTruck = await _foodTruckService.GetFullFoodTruckInfoAsync(id);
            var foodTruckDto = _mapper.Map<FoodTruck, FoodTruckDto>(foodTruck);
            
            if (foodTruck != null)
            {

                return View(foodTruckDto);
            }

            return NotFound();
        }

    }
}
