using FoodTrakker.Core.Model;

namespace FoodTrakkerWebAplication.Models.ViewModel
{
    public class FoodTruckEventViewModel
    {
        public IEnumerable<FoodTruck> Foodtrucks { get; set; }
        public IEnumerable<Event> Events { get; set; }
    }
}
