using FoodTrakker.Repository;
using FoodTrakker.Core.Model;

namespace FoodTrakker.Services
{
    public class FoodTruckService
    {
        private readonly IRepository<FoodTruck> _foodTruckRepository;
        public FoodTruckService(IRepository<FoodTruck> foodTruckRepository)
        {
            _foodTruckRepository = foodTruckRepository;
        }
        public async Task<ICollection<FoodTruck>> GetFoodTrucksAsync()
        { 

            return await _foodTruckRepository.GetAsync();

        }

        public async Task<FoodTruck> GetFoodTruckAsync(int Id)
        {
            return await _foodTruckRepository.GetAsync(Id);
        }
    }
}
