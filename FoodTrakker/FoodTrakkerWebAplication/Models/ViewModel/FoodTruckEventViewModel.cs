

using FoodTrakker_WebBusinessLogic.Model;

namespace FoodTrakkerWebAplication.Models.ViewModel
{
    public class FoodTruckEventViewModel
    {
        public IEnumerable<FoodTruck> Foodtrucks { get; set; }
        public IEnumerable<Event> Events { get; set; }
    }
}
