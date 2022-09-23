using FoodTrakker.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrakker.Core.LinkingClasses;

namespace FoodTrakker.Repository.Contracts
{
    public interface IFoodTruckRepository : IRepository<FoodTruck, int>
    {
        public Task<List<FoodTruck>> GetFullFoodTruckInfoAsync();
        public Task<FoodTruck> GetFullFoodTruckInfoAsync(int Id);
        public Task<List<FoodTruck>> GetOwnerFoodTrucks(string ownerId);
        public Task<List<FoodTruck>> FindFoodTruckAsync(string Name);
        public Task<List<FoodTruck>> FindByCityAsync(string City);
        public Task<List<FoodTruck>> FindByStreetAsync(string City);
        public Task<List<FoodTruck>> FindByTypeAsync(string Type);
        
        Task<(double, int)> AvgRatingAndReviewCount(int Id);
        Task<bool> HasFoodTruckReviewFromUser(int foodTruckId, string userId);
        Task<bool> IsAddedToFav(int id, string userId);
        Task SaveChanges();

    }
}
