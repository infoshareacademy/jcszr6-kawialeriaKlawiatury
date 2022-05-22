using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using FoodTrakker.BusinessLogic.Models;


namespace FoodTrakker.BusinessLogic
{
    public class  FoodTruckRepository
    {
        private static readonly List<FoodTruck> _foodTrucks = new List<FoodTruck>();


        public static List<FoodTruck> GetAllFoodTrucks()
        {
            return _foodTrucks;
        }

        public static void AddFoodTruck(FoodTruck foodTruck)
        {
            _foodTrucks.Add(foodTruck);
        }
    }
}
