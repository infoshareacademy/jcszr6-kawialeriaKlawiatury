
using AutoMapper;
using FoodTrakker.Core.Model;
using FoodTrakker.Services;
using FoodTrakker.Services.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FoodTrakkerWebAplication.ViewComponents
{
    public class EventFoodTrucks : ViewComponent
    {
        private readonly FoodTruckService _foodTruckService;
        private readonly EventService _eventService;
        private readonly IMapper _mapper;
        public EventFoodTrucks(FoodTruckService foodTruckService,EventService eventService , IMapper mapper)
        {
            _foodTruckService = foodTruckService;
            _eventService = eventService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync(EventDto eEvent)
        {
            var @event = _mapper.Map<EventDto, Event>(eEvent);
            var foodTrucks = await _eventService.GetEventFoodTrucks(@event);

            var foodTrucksDto = _mapper.Map<List<FoodTruck>, List<FoodTruckDto>>(foodTrucks);

            return View(foodTrucksDto);
        }
        
    }
}
