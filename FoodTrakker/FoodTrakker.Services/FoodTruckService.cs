using FoodTrakker.Core;
using FoodTrakker.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrakker.Core.Model;

namespace FoodTrakker.Services
{
    public class FoodTruckService
    {
        private readonly FoodTruckRepository _foodTruckRepository;
        public FoodTruckService(FoodTruckRepository foodTruckRepository)
        {
            _foodTruckRepository = foodTruckRepository;
        }
        public async Task<ICollection<FoodTruck>> GetFoodTrucksAsync()
        { 

            return await _foodTruckRepository.GetAsync();

        }
    }
}
