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
        public async Task<ICollection<FoodTruck>> GetFoodTrucksAsync()
        {
            return await _foodTruckRepository.GetAsync();
        }

        public async Task<ICollection<FoodTruck>> GetFullFoodTruckInfoAsync()
        {
            return await _foodTruckRepository.GetFullFoodTruckInfoAsync();
        }

        public async Task<FoodTruck> GetFullFoodTruckInfoAsync(int Id)
        {
            return await _foodTruckRepository.GetFullFoodTruckInfoAsync(Id);
        }

        public async Task<FoodTruck> GetFoodTruckAsync(int Id)
        {
            return await _foodTruckRepository.GetAsync(Id);
        }
    }
}
