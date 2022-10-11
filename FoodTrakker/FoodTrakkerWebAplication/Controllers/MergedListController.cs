using AutoMapper;
using FoodTrakker.Services;
using FoodTrakker.Core.Model;
using FoodTrakker.Core.LinkingClasses;
using FoodTrakker.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using FoodTrakker.Services.DTOs;

namespace FoodTrakkerWebAplication.Controllers
{
    public class MergedListController : Controller
    {
        private readonly FoodTruckService _foodTruckService;
        private readonly UserService _userService;
        private readonly LocationService _locationService;
        private readonly MergedListService _mergedListService;
        private readonly ReviewService _reviewService;

        private readonly IMapper _mapper;
        public MergedListController(FoodTruckService foodTruckService,
            UserService userService,
            LocationService locationService,
            MergedListService mergedListService,
            ReviewService reviewService,
            IMapper mapper)
        {
            _foodTruckService=foodTruckService;
            _userService=userService;
            _locationService=locationService;
            _reviewService = reviewService;
            _mergedListService=mergedListService;

            _mapper =mapper;
        }

        public async Task<ActionResult> Index()
        {
            var foodTrucks = new List<FoodTruck>();
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

            if (foodTrucks == null)
            {
                return View();
            }

            var foodTrucksDto = _mapper.Map<List<FoodTruckDto>>(foodTrucks);

            return View(foodTrucksDto);

        }




        // GET: MergedListController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MergedListController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MergedListController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MergedListController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MergedListController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MergedListController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MergedListController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
