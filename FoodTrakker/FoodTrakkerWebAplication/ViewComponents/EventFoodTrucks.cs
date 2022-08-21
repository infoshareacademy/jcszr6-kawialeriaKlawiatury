
using FoodTrakker.Core.Model;
using FoodTrakker.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodTrakkerWebAplication.ViewComponents
{
    public class EventFoodTrucks : ViewComponent
    {
        private readonly FoodTruckService _foodTruckService;

        public EventFoodTrucks(FoodTruckService foodTruckService)
        {
            _foodTruckService = foodTruckService;
        }

        public async Task<IViewComponentResult> InvokeAsync(Event eEvent)
        {
            var foodTrucks = new List<FoodTruck>();
            foreach (var foodTruckEvent in eEvent.FoodTruckEvents)
            {
                var foodTruckId = foodTruckEvent.FoodTruckId;
                var foodTruck = await _foodTruckService.GetFullFoodTruckInfoAsync(foodTruckId);
                if (foodTruck != null)
                {
                    foodTrucks.Add(foodTruck);
                }
            }

            return View(foodTrucks);
        }
    }
}
