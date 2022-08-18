using FoodTrakker.Core.Model;
using FoodTrakker.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrakker.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> GetUserAsync(string Id)
        {
            return await _userRepository.GetAsync(Id);
        }

        public async Task<User> GetAllUserDataAsync(string Id)
        {
            return await _userRepository.GetAllUserData(Id);
        }
        public Task<ICollection<FoodTruck>>GetFavFoodTrucks (string Id)
        {
            return _userRepository.FavFoodTrucks(Id);
        }
         

    }
}
