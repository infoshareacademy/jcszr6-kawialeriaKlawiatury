using FoodTrakker.Services.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodTrakkerWebAplication.Models.ViewModel
{
    public class FoodTruckTypesViewModel
    {
        public List<FoodTruckDto>? FoodTrucks { get; set; }
        public SelectList? Types { get; set; }
        public string? Type { get; set; }
        public string? SearchString { get; set; }
    }
}
