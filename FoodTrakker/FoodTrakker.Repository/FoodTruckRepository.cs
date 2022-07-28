using FoodTrakker.Core.Model;
using FoodTrakker.Repository.Contracts;
using FoodTrakker.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace FoodTrakker.Repository
{
    public class FoodTruckRepository : Repository<FoodTruck>, IFoodTruckRepository
    {
        private readonly FoodTrakkerContext _context;
        public FoodTruckRepository(FoodTrakkerContext context) : base(context)
        {
            _context = context;
        }

        public Task<List<FoodTruck>> GetFullFoodTruckInfoAsync()
        {
            return Task.FromResult(_context.FoodTrucks
                .Include(f => f.Location)
                .Include(f => f.Type)
                .ToList());
        }

        public Task<FoodTruck> GetFullFoodTruckInfoAsync(int Id)
        {
            return _context.FoodTrucks
                .Include(f => f.Location)
                .Include(f => f.Type).SingleOrDefaultAsync(f => f.Id == Id);
        }


        public Task<List<FoodTruck>> GetOwnerFoodTrucks(string ownerId)
        {
            return Task.FromResult(_context.FoodTrucks
                 .Include(f => f.Location)
                 .Include(f => f.Type)
                 .Where(f => f.OwnerId == ownerId)
                 .ToList());
        }
    }
}
