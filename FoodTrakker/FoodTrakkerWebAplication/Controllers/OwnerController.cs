﻿
using AutoMapper;
using FoodTrakker.Core.Model;
using FoodTrakker.Repository;
using FoodTrakker.Repository.Constants;
using FoodTrakker.Services;
using FoodTrakker.Services.DTOs;
using FoodTrakkerWebAplication.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using System.Security.Claims;

namespace FoodTrakkerWebAplication.Controllers
{
    [Authorize(Roles = Roles.Administrator + "," + Roles.Owner)]
    public class OwnerController : Controller
    {
        private readonly FoodTruckService _foodTruckService;
        private readonly EventService _eventService;
        private readonly LocationService _locationService;
        private readonly TypeService _typeService;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        
        public OwnerController(
            EventService eventService, 
            FoodTruckService foodTruckService, 
            LocationService locationService,
            TypeService typeService,
            UserManager<User> userManager, 
            IMapper mapper)
        {
            _eventService = eventService;
            _foodTruckService = foodTruckService;
            _userManager = userManager;
            _mapper = mapper;
            _locationService = locationService;
            _typeService = typeService;
        }


        // GET: OwnerController
        public async Task<ActionResult> Index()
        {          
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var events = await _eventService.GetEventsAsync();
            var foodTrucks = await _foodTruckService.GetFullFoodTruckInfoAsync();
            var uEViewModel = new FoodTruckEventViewModel();

            uEViewModel.Events = _mapper.Map<List<Event>, List<EventDto>>(events.ToList());
            uEViewModel.Foodtrucks = _mapper.Map<List<FoodTruck>, List<FoodTruckDto>>(foodTrucks.ToList());

            return View(uEViewModel);
        }

        // GET: OwnerController/Details/5
        public async Task<ActionResult> DetailsFoodTruck(int id)
        {
            var foodTruck = await _foodTruckService.GetFullFoodTruckInfoAsync(id);
            var foodTruckDto = _mapper.Map<FoodTruck, FoodTruckDto>(foodTruck);
            if (foodTruckDto != null)
            {
                return View(foodTruckDto);
            }
            return NotFound();
        }

        // GET: OwnerController/Details/5
        public async Task<ActionResult> DetailsEvent(int id)
        {
            var events = await _eventService.GetFullEventInfoAsync(id);
            var eventDto = _mapper.Map<Event, EventDto>(events);
            if (eventDto != null)
            {

                return View(eventDto);
            }

            return NotFound();
        }

        // GET: OwnerController/Create
        public async Task<ActionResult> CreateFoodTruck()
        {
            var locations = await _locationService.GetLocationsAsync();
            var locationSelect = new List<SelectListItem>();

            if(locations != null)
            {
                foreach (var location in locations)
                {                   
                    locationSelect.Add(new SelectListItem { Text = $"{location.City} {location.Street}", Value = $"{location.Id}" });                  
                }
            }

            ViewBag.LocationSelect = locationSelect;

            var types = await _typeService.GetTypesAsync();
            var typesSelect = new List<SelectListItem>();

            if (types != null)
            {
                foreach (var type in types)
                {
                    typesSelect.Add(new SelectListItem { Text = $"{type.Name}", Value = $"{type.Id}" });
                }
            }

            ViewBag.TypesSelect = typesSelect;


            return View();
        }

        // POST: OwnerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateFoodTruck(FoodTruckDto foodTruckDto, int locationId, int typeId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var foodTrucks = await _foodTruckService.GetFullFoodTruckInfoAsync();          
            
            var index = foodTrucks.OrderBy(f => f.Id).Last().Id;
            foodTruckDto.Id = foodTrucks.Max(f => f.Id) + 1;
            foodTruckDto.OwnerId = userId; //Temporary value to be updated!!!
            foodTruckDto.Location = await _locationService.GetLocationAsync(locationId);
            foodTruckDto.Type = await _typeService.GetTypeAsync(typeId);

            var errors = ModelState.SelectMany(m => m.Value.Errors);
            if (!ModelState.IsValid)
            {
                return RedirectToAction("CreateFoodTruck");
            }

            try
            {
                var foodTruck = _mapper.Map<FoodTruckDto, FoodTruck>(foodTruckDto);
                await _foodTruckService.AddFoodTruck(foodTruck);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OwnerController/Edit/5
        public async Task<ActionResult> EditFoodTruck(int id)
        {
            var foodTruckToEdit = await _foodTruckService.GetFoodTruckAsync(id);
            return View(foodTruckToEdit);
        }

        // POST: OwnerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditFoodTruck(int id, FoodTruck foodTruck)
        {
            if (!ModelState.IsValid)
            {
                return View(foodTruck);
            }
            var foodTruckToEdit = await _foodTruckService.GetFoodTruckAsync(id);
            try
            {
                foodTruckToEdit.Name = foodTruck.Name;
                foodTruckToEdit.Description = foodTruck.Description;
                foodTruckToEdit.Type.Name = foodTruck.Type.Name;
                foodTruckToEdit.Location.City = foodTruck.Location.City;
                foodTruckToEdit.Location.Street = foodTruck.Location.Street;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OwnerController/Delete/5
        public async Task<ActionResult> DeleteFoodTruck(int id)
        {
            var foodTruckToDelete = await _foodTruckService.GetFoodTruckAsync(id);
            return View(foodTruckToDelete);
        }

        // POST: OwnerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteFoodTruck(int id, FoodTruck foodTruck)
        {
            throw new NotImplementedException();
        }
        //GET: OwnerController/Delete/5
        public async Task<ActionResult> DeleteEvent(int id)
        {
            var events = await _eventService.GetEventAsync(id);

            return View(events);
        }

        // POST: OwnerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteEvent(int id, Event eventToDelete)
        {
            try
            {
                _eventService.GetEventAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(eventToDelete);
            }
        }
    }

}
