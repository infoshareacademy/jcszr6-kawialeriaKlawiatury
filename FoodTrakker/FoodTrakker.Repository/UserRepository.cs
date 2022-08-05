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

        public async Task<User> GetUserWithFavFoodTrucsAsync(string userId)
        {
            return await _context.Users.Include(u => u.FavouriteFoodTrucks)
                .FirstOrDefaultAsync(u => u.Id.Equals(userId));
        }
    }
}
