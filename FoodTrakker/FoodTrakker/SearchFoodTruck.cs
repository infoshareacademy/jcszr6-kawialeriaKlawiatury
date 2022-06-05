using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrakker.BusinessLogic.Models;
using FoodTrakker.BusinessLogic.Repository;

namespace FoodTrakker.BusinessLogic
{
    public class SearchFoodTruck
    {
        public static FoodTruck Search(string name)
        {
            var foodTruckList = DataRepository<FoodTruck>.GetData();
            var foodTruck = foodTruckList.FirstOrDefault(f => f.Name.Contains(name));
            return foodTruck;
        }
    }
}
