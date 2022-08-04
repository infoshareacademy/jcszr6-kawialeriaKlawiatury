using FoodTrakker.Core.Model;
using FoodTrakker.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrakker.Services
{
    public class FavouritesFoodTruckService
    {
        private readonly IUserRepository _userRepository;
        public FavouritesFoodTruckService(IUserRepository userRepository)
        {
            _userRepository = userRepository; 
;
        }
     
        
    }
}
