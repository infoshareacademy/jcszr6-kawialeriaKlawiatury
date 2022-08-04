using FoodTrakker.Core.Model;
using FoodTrakker.Repository.Contracts;
using FoodTrakker.Repository.Data;

namespace FoodTrakker.Repository
{
    public class UserRepository : Repository<User> , IUserRepository
    {
       
        public UserRepository(FoodTrakkerContext context) : base(context)
        {
          
        }
       
    }
}
