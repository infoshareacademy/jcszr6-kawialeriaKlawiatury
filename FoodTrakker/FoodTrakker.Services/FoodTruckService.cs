using AutoMapper;
using FoodTrakker.Repository;
using FoodTrakker.Core.Model;
using FoodTrakker.Repository.Contracts;

namespace FoodTrakker.Services
{
    public class FoodTruckService
    {
        private readonly IFoodTruckRepository _foodTruckRepository;
        private readonly IRepository<FoodTruckType, string> _foodTruckTypeRepository;
        private readonly IRepository<Review, string> _reviewRepository;
        private readonly IMapper _mapper;
        public FoodTruckService(IFoodTruckRepository foodTruckRepository, IRepository<FoodTruckType, string> foodTruckTypeRepository, IMapper mapper, IRepository<Review, string> reviewRepository )
        {
            _foodTruckRepository = foodTruckRepository;
            _foodTruckTypeRepository = foodTruckTypeRepository;
            _reviewRepository = reviewRepository;
            _mapper = mapper;

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
        public Task<List<FoodTruck>> FindFoodTruckAsync(string Name)
        {
            return _foodTruckRepository.FindFoodTruckAsync(Name);
        }

        public void IsNameUnique(string name)
        {
            throw new NotImplementedException();
        }
        public Task<List<FoodTruck>> FindByCityAsync(string City)
        {
            return _foodTruckRepository.FindByCityAsync(City);
        }

        public Task<List<FoodTruck>> FindByStreetAsync(string City)
        {
            return _foodTruckRepository.FindByStreetAsync(City);
        }

        public Task<List<FoodTruck>> FindByTypeAsync(string Type)
        {
            return _foodTruckRepository.FindByTypeAsync(Type);
        }

        //public async Task<IEnumerable<string>> GetFoodTruckReviewRates()
        //{
        //    var rates = await _reviewRepository.GetAsync();
        //    return rates.Select(x => x.Rating.ToString());
        //}

        public async Task<IEnumerable<string>> GetFoodTruckTypeNames()
        {
            var types = await _foodTruckTypeRepository.GetAsync();
            return types.Select(x => x.Name);
        }
        //public Task<List<FoodTruck>> FindByEventAsync(string EventName)
        //{
        //    return _foodTruckRepository.FindByEventAsync(EventName);
        //}
    }
}
