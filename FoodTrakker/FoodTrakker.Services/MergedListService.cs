using FoodTrakker.Core.LinkingClasses;
using FoodTrakker.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrakker.Services
{
    public  class MergedListService
    {
        private readonly IFoodTruckRepository _foodTruckRepository;
        private readonly IUserRepository _userRepository;
        public MergedListService(IFoodTruckRepository foodTruckRepositor,
            IUserRepository userRepository)
        {
            _foodTruckRepository = foodTruckRepositor;
            _userRepository=userRepository; 
        }
        //public async Task<MergedList> GetFoodTrucksAsync(string userId)
        //{
        //    var foodTrucks = await _foodTruckRepository.GetFullFoodTruckInfoAsync();
        //    var user = await _userRepository.GetAsync(userId);

        //    var mergedList = new MergedList()
        //    {
        //        FoodTruck = 
        //    }
        //}
        
        //public Task<MergedList> GetTypeAsync(string FoodTruck, int Review, string Location, string User)
        //{
        //    return _mergedListRepository.GetAsync(FoodTruck,Review,Location,User);
        //}

        

    }
}
