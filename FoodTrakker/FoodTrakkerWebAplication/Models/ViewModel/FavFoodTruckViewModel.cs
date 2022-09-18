using FoodTrakker.Core.Model;
using FoodTrakker.Services.DTOs;

namespace FoodTrakkerWebAplication.Models.ViewModel
{
    public class FavFoodTruckViewModel
    {
        public FoodTruck foodTruck { get; set; }
        public User user { get; set; }
    }
}
