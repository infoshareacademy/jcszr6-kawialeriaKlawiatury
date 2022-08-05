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
        Task<User> GetUserWithFavFoodTrucsAsync(string userId);
    }

}
