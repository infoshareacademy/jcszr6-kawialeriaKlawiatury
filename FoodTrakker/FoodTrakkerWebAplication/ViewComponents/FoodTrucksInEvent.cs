using AutoMapper;
using FoodTrakker.Core.Model;
using FoodTrakker.Services;
using FoodTrakker.Services.DTOs;
using Microsoft.AspNetCore.Mvc;


namespace FoodTrakkerWebAplication.ViewComponents
{
    public class FoodTrucksInEvent : ViewComponent
    {
        private readonly FoodTruckService _foodTruckService;
        private readonly IMapper _mapper;
        public FoodTrucksInEvent(FoodTruckService foodTruckService,IMapper mapper)
        {
            _foodTruckService = foodTruckService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync(EventDto eEvent)
        {
           var foodTrucks = new List<FoodTruck>();
           var foodTrucksDto = _mapper.Map<List<FoodTruck>, List<FoodTruckDto>>(foodTrucks);
            foreach (var foodTruckEvent in eEvent.FoodTruckEvents)
            {
               var foodTruckId = foodTruckEvent.FoodTruckId;
               var foodTruck = await _foodTruckService.GetFullFoodTruckInfoAsync(foodTruckId);
               var foodTruckDto = _mapper.Map<FoodTruck,FoodTruckDto>(foodTruck);
                if (foodTruckDto != null)
                {
                    foodTrucksDto.Add(foodTruckDto);
                }
            }

            return View(foodTrucksDto);
        }
    }
}
