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

            var foodTruck = await _context.FoodTrucks
                .Include(f => f.Location)
                .FirstOrDefaultAsync(f => f.Id == foodTruckId);

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
            var foodTruck = await _context.FoodTrucks
                .AsTracking()
                .Include(f => f.Location)
                .FirstOrDefaultAsync(f => f.Id == foodTruckId);
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
            var userReviews = await _context.Reviews.Where(r => r.UserId == userId)
                .Include(r => r.FoodTruck)
                .ToListAsync();

            return userReviews;
        }

        public async Task<User> GetAllUserData(string userId)
        {
            return await _context.Users.Include(u => u.FavouriteFoodTrucks)
                                        //.Include(u => u.Reviews)
                                        .FirstOrDefaultAsync(u => u.Id == userId);
        }

   }
}
