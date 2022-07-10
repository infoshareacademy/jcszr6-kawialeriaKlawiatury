


using FoodTrakker.Core;
using FoodTrakker.Repository.Data;

namespace FoodTrakker.Repository
{
    public class FoodTruckRepository : Repository<FoodTruck>
    {
        public FoodTruckRepository(FoodTrakkerContext context) :base(context)
        {
        }
    }
}
