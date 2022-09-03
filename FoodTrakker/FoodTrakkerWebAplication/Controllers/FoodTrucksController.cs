﻿using AutoMapper;
using FoodTrakker.Core.Model;
using Microsoft.AspNetCore.Mvc;
using FoodTrakker.Services;
using FoodTrakker.Repository;
using FoodTrakker.Services.DTOs;
using FoodTrakkerWebAplication.Models.ViewModel;

namespace FoodTrakkerWebAplication.Controllers
{
    public class FoodTrucksController : Controller
    {
        private readonly FoodTruckService _foodTruckService;
        private readonly UserService _userService;
        private readonly IMapper _mapper;


        public FoodTrucksController(FoodTruckService foodTruckService, IMapper mapper, UserService userService)
        {
            _foodTruckService = foodTruckService;
            _userService = userService;
            _mapper = mapper;

        }

        public async Task<ActionResult> Index(string EventName, string Type, string searchString, string citySearchString, string streetSearchString)
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
            //else if (!String.IsNullOrEmpty(EventName))
            //{
            //    foodTrucks = await _foodTruckService.FindByEventAsync(EventName);
            //}
            else
            {
                foodTrucks = await _foodTruckService.GetFullFoodTruckInfoAsync();
            }



            var foodTruckDto = _mapper.Map<ICollection<FoodTruck>,
                ICollection<FoodTruckDto>>(foodTrucks);

            //var foodTruckReviewRate = new FoodTruckTypeDto { FoodTrucks = foodTruckDto };
            //foodTruckReviewRate.FoodTruckReviewRate = await _foodTruckService.GetFoodTruckReviewRates();

            var foodTruckTypeDto = new FoodTruckTypeDto { FoodTrucks = foodTruckDto };
            foodTruckTypeDto.FoodTruckTypeName = await _foodTruckService.GetFoodTruckTypeNames();

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
            foodTruckDto.AvgRating = await _foodTruckService.AvgRatingCount(id);
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
