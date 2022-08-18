using FoodTrakker.Core.Model;
using FoodTrakker.Repository.Contracts;
using FoodTrakker.Repository.Data;
using Microsoft.EntityFrameworkCore;


namespace FoodTrakker.Services
{
    public class FavouritesFoodTruckService
    {
        private readonly IUserRepository _userRepository;
              
        public FavouritesFoodTruckService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<FoodTruck> AddFoodTruckToFavourites(int foodTruckId, string userId)
        {
            var foodTruck = await _userRepository.AddFavFoodTrucToUserAsync(userId,foodTruckId);
            return foodTruck;
        }
        public async Task<FoodTruck> RemoveFoodTruckFromFavourites(int foodTruckId, string userId)
        {
            var foodTruck = await _userRepository.RemoveFavFoodTruckFromUserAsync(userId, foodTruckId);
            return foodTruck;
        }
        public async Task<ICollection<FoodTruck>> FavFoodTrucks(string userId)
        {
            return await _userRepository.FavFoodTrucks(userId);
        }
        public async Task<List<Review>> UserReviews(string userId)
        {
            return await _userRepository.UserReviews(userId);
        }

    }
}