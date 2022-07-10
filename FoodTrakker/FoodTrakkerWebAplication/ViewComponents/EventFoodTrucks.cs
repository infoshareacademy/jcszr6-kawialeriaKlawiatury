
using Microsoft.AspNetCore.Mvc;

namespace FoodTrakkerWebAplication.ViewComponents
{
    public class EventFoodTrucks : ViewComponent
    {
        //private readonly IRepository<FoodTruck> _foodTruckRepository;

        //public EventFoodTrucks(IRepository<FoodTruck> foodTruckRepository)
        //{
        //    _foodTruckRepository = foodTruckRepository;
        //}

        //public async Task<IViewComponentResult> InvokeAsync(Event eEvent)
        //{
        //    var foodTrucks = new List<FoodTruck>();
        //    foreach (var id in eEvent.FoodTrucksId)
        //    {
        //        var foodTruck = await _foodTruckRepository.GetAsync(id);
        //        if (foodTruck != null)
        //        {
        //            foodTrucks.Add(foodTruck);
        //        }
        //    }
            
        //    return View(foodTrucks);
        //}
    }
}
