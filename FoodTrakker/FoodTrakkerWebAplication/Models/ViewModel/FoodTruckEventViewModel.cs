using FoodTrakker.Core.Model;
using FoodTrakker.Services.DTOs;

namespace FoodTrakkerWebAplication.Models.ViewModel
{
    public class FoodTruckEventViewModel
    {
        public List<FoodTruckDto> Foodtrucks { get; set; }
        public List<EventDto> Events { get; set; }
    }
}
