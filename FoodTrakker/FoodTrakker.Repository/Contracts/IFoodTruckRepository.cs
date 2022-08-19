using FoodTrakker.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        Task SaveChanges();
        public Task<List<FoodTruck>> FindByTypeAsync(string Type);
        //public Task<List<FoodTruck>> FindByEventAsync(string Event);


    }
}
