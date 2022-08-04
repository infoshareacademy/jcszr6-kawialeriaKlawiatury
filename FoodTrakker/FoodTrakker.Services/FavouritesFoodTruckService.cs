using FoodTrakker.Core.Model;
using FoodTrakker.Repository;
using FoodTrakker.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrakker.Services
{
    public class FavouritesFoodTruckService
    {
        private readonly IUserRepository _userRepository;
        private readonly IFoodTruckRepository _foodTruckRepository;
        public FavouritesFoodTruckService(IUserRepository userRepository, IFoodTruckRepository foodTruckRepository)
        {
            _userRepository = userRepository;
            _foodTruckRepository = foodTruckRepository;
            
        }
        public async Task AddFoodTruckToFavourites(int foodTruckId, int userId)
        {
            var foodTruckTask = _foodTruckRepository.GetAsync(foodTruckId);
            var userTask = _userRepository.GetAsync(userId);
            await Task.WhenAll(foodTruckTask, userTask);
            var user = userTask.Result;
            var foodTruck = foodTruckTask.Result;
            user.FavouriteFoodTrucks.Add(foodTruck);
            await _foodTruckRepository.SaveChanges();
        }
    }
}