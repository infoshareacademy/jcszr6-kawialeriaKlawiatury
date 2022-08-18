using FoodTrakker.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrakker.Repository.Contracts
{
    public interface IUserRepository : IRepository<User, string>
    {
        Task<FoodTruck> AddFavFoodTrucToUserAsync(string userId, int foodTruckId);
        Task<FoodTruck> RemoveFavFoodTruckFromUserAsync(string userId, int foodTruckId);
        Task<ICollection<FoodTruck>> FavFoodTrucks(string userId);
        Task<List<Review>> UserReviews(string userId);
    }

}
