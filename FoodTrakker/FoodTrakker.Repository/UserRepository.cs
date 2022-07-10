
using FoodTrakker.Core;
using FoodTrakker.Repository.Data;

namespace FoodTrakker.Repository
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(FoodTrakkerContext context) : base(context)
        {
        }
    }
}
