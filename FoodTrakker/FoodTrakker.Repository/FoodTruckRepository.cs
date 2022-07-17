using FoodTrakker.Core.Model;
using FoodTrakker.Repository.Data;

namespace FoodTrakker.Repository
{
    public class FoodTruckRepository : Repository<FoodTruck> 
    {
        private readonly FoodTrakkerContext _context;
        public FoodTruckRepository(FoodTrakkerContext context) :base(context)
        {
            _context = context;
        }
    }
}
