using FoodTrakker.Core.Model;
using FoodTrakker.Repository.Contracts;

namespace FoodTrakker.Services
{
    public class FoodTruckService
    {
        private readonly IFoodTruckRepository _foodTruckRepository;
        public FoodTruckService(IFoodTruckRepository foodTruckRepository)
        {
            _foodTruckRepository = foodTruckRepository;
        }
        public Task<List<FoodTruck>> GetFoodTrucksAsync()
        {
            return _foodTruckRepository.GetAsync();
        }
        public Task<FoodTruck> GetFoodTruckAsync(int Id)
        {
            return _foodTruckRepository.GetAsync(Id);
        }

        public Task<List<FoodTruck>> GetFullFoodTruckInfoAsync()
        {
            return _foodTruckRepository.GetFullFoodTruckInfoAsync();
        }

        public Task<FoodTruck> GetFullFoodTruckInfoAsync(int Id)
        {
            return _foodTruckRepository.GetFullFoodTruckInfoAsync(Id);
        }

        public Task<List<FoodTruck>> GetOwnerFoodTrucks(string ownerId)
        {
            return _foodTruckRepository.GetOwnerFoodTrucks(ownerId);
        }

        public Task AddFoodTruck(FoodTruck foodTruck)
        {
            return _foodTruckRepository.AddAsync(foodTruck);
        }

        public Task UpdateFoodTruck(FoodTruck foodTruck)
        {
            return _foodTruckRepository.UpdateAsync(foodTruck);
        }

        public Task DeleteFoodTruck(int foodTruckId)
        {
            return _foodTruckRepository.DeleteAsync(foodTruckId);
        }

        public void IsNameUnique(string name)
        {
            throw new NotImplementedException();
        }
    }
}
