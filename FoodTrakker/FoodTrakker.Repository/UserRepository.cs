using FoodTrakker.Core.Model;
using FoodTrakker.Repository.Contracts;
using FoodTrakker.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace FoodTrakker.Repository
{
    public class UserRepository : Repository<User, string> , IUserRepository
    {
       
        public UserRepository(FoodTrakkerContext context) : base(context)
        {
          
        }

        public async Task<FoodTruck> AddFavFoodTrucToUserAsync(string userId,int foodTruckId)
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
        public async Task<FoodTruck> RemoveFavFoodTruckFromUserAsync(string userId, int foodTruckId)
        {
            var foodTruck = await _context.FoodTrucks.AsTracking().FirstOrDefaultAsync(f => f.Id == foodTruckId);
            var user = await _context.Users.Include(u => u.FavouriteFoodTrucks).AsTracking()
                .FirstOrDefaultAsync(u => u.Id.Equals(userId));
           user.FavouriteFoodTrucks.Remove(foodTruck);
            var result = await _context.SaveChangesAsync();

            return foodTruck;
        }
        public async Task<ICollection<FoodTruck>> FavFoodTrucks(string userId)
        {
            var user = await _context.Users.Include(u => u.FavouriteFoodTrucks).AsTracking()
                .FirstOrDefaultAsync(u => u.Id.Equals(userId));
            var foodTrucks = user.FavouriteFoodTrucks;

            return foodTrucks;
        }

        public async Task<List<Review>> UserReviews(string userId)
        {
            var user = await _context.Users.Include(u => (u as User).Reviews)
               .FirstOrDefaultAsync(u => u.Id.Equals(userId));
            var reviews = user.Reviews;

            return reviews;
        }  
    }
}
