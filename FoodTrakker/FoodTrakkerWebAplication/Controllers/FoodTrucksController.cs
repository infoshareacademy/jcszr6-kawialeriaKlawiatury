using AutoMapper;
using FoodTrakker.Core.Model;
using Microsoft.AspNetCore.Mvc;
using FoodTrakker.Services;
using FoodTrakker.Repository;
using FoodTrakker.Services.DTOs;
using FoodTrakkerWebAplication.Models.ViewModel;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodTrakkerWebAplication.Controllers
{
    public class FoodTrucksController : Controller
    {
        private readonly FoodTruckService _foodTruckService;
        private readonly UserService _userService;
        private readonly IMapper _mapper;
        private readonly EventService _eventService;


        public FoodTrucksController(EventService eventService, FoodTruckService foodTruckService, IMapper mapper, UserService userService)
        {
            _foodTruckService = foodTruckService;
            _userService = userService;
            _mapper = mapper;
            _eventService = _eventService;

        }

        public async Task<ActionResult> Index(string EventName, string Type, string searchString, string citySearchString, string streetSearchString, int averageRating)
        {

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
            else if (!String.IsNullOrEmpty(Type))
            {
                foodTrucks = await _foodTruckService.FindByTypeAsync(Type);
            }
            else if (!String.IsNullOrEmpty(EventName))
            {
                foodTrucks = await _foodTruckService.FindByEventAsync(EventName);
            }
            else if (averageRating !=0)
            {
                var foodTrucksToFilter = await _foodTruckService.GetFullFoodTruckInfoAsync();
                var foodTrucksDtos = _mapper.Map<List<FoodTruckDto>>(foodTrucksToFilter);
                foreach (var dto in foodTrucksDtos)
                {
                    (dto.AvgRating, dto.ReviewsTotalCount) = await _foodTruckService.AvgRatingCount(dto.Id);
                }
                var foodTruckTypeDtos = new FoodTruckTypeDto { FoodTrucks = foodTrucksDtos.Where(e => e.AvgRating >= averageRating) };
                foodTruckTypeDtos.FoodTruckTypeName = await _foodTruckService.GetFoodTruckTypeNames();

                return View(foodTruckTypeDtos);
            }
            else
            {
                var foodTrucksNotInLocation = new List<FoodTruck>();
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (userId != null)
                {
                    foodTrucks = await _foodTruckService.GetFoodTrucksByUserLocation(userId);
                    foodTrucksNotInLocation = await _foodTruckService.GetFoodTruckNotInUserLocation(userId);
                    foreach (var foodTruck in foodTrucksNotInLocation)
                    {
                        foodTrucks.Add(foodTruck);
                    }
                }

                if (userId == null)
                {
                    foodTrucks = await _foodTruckService.GetFullFoodTruckInfoAsync();
                }
            }



            var foodTruckDto = _mapper.Map<ICollection<FoodTruck>,
                ICollection<FoodTruckDto>>(foodTrucks);

            var foodTruckTypeDto = new FoodTruckTypeDto { FoodTrucks = foodTruckDto };
            foodTruckTypeDto.FoodTruckTypeName = await _foodTruckService.GetFoodTruckTypeNames();

            foreach (var ftBto in foodTruckTypeDto.FoodTrucks)
            {
                (ftBto.AvgRating, ftBto.ReviewsTotalCount) = await _foodTruckService.AvgRatingCount(ftBto.Id);
            }

            ViewBag.RatingList = new List<SelectListItem>
            {
                new SelectListItem{Text = "1", Value = "1"},
                new SelectListItem{Text = "2", Value = "2"},
                new SelectListItem{Text = "3", Value = "3"},
                new SelectListItem{Text = "4", Value = "4"},
                new SelectListItem{Text = "5", Value = "5"},
            };

            return View(foodTruckTypeDto);
        }

        //GET: FoodTrucksController/Details/5
        public async Task<ActionResult> Details(int id)
        {

            var foodTruck = await _foodTruckService.GetFullFoodTruckInfoAsync(id);
            var foodTruckDto = _mapper.Map<FoodTruck, FoodTruckDto>(foodTruck);
            if (foodTruckDto == null)
            {
                return NotFound();
            }
            (foodTruckDto.AvgRating, foodTruckDto.ReviewsTotalCount) = await _foodTruckService.AvgRatingCount(id);
            if (User.Identity.IsAuthenticated)
            {
                var x = User.Claims.FirstOrDefault(c => c.Type == @"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
                foodTruckDto.IsAddedToFav = await _foodTruckService.IsAddedToFav(id, x.Value);
                foodTruckDto.HasCurrentUserReview = await _foodTruckService.HasFoodTruckReviewFromUser(id, x.Value);
            }

            return View(foodTruckDto);
        }


    }
}
