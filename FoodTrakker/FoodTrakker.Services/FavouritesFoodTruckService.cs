using FoodTrakker.Core.Model;
using FoodTrakker.Repository.Contracts;
using FoodTrakker.Repository.Data;
using Microsoft.EntityFrameworkCore;


namespace FoodTrakker.Services
{
    public class FavouritesFoodTruckService
    {
        private readonly IUserRepository _userRepository;
        private readonly IFoodTruckRepository _foodTruckRepository;
        private readonly FoodTrakkerContext _context;
        public FavouritesFoodTruckService(IUserRepository userRepository, IFoodTruckRepository foodTruckRepository, FoodTrakkerContext context)
        {
            _userRepository = userRepository;
            _foodTruckRepository = foodTruckRepository;
            _context = context;

        }
        public async Task<FoodTruck> AddFoodTruckToFavourites(int foodTruckId, string userId)
        {
            var foodTruck = await _context.FoodTrucks.FirstOrDefaultAsync(f => f.Id == foodTruckId);
            var user = await _context.Users.Include(u => u.FavouriteFoodTrucks)
                .FirstOrDefaultAsync(u => u.Id.Equals(userId));
            _context.Attach(user);
            _context.Attach(foodTruck);
            user.FavouriteFoodTrucks.Add(foodTruck);

            var result = await _context.SaveChangesAsync();

            return foodTruck;
        }
    }
}