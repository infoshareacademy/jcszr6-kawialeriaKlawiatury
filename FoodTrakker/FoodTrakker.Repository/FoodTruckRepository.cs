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

        public Task<List<FoodTruck>> FindByCityAsync(string City)
        {
            return _context.FoodTrucks.Where(f => f.Location.City.Contains(City))
                .Include(f => f.Location)
                .Include(f => f.Type)
                .ToListAsync();
        }

        public Task<List<FoodTruck>> FindByStreetAsync(string Street)
        {
            return _context.FoodTrucks.Where(f => f.Location.Street.Contains(Street))
                .Include(f => f.Location)
                .Include(f => f.Type)
                .ToListAsync();
        }

        public Task<List<FoodTruck>> FindFoodTruckAsync(string Name)
        {
            return _context.FoodTrucks.Where(f => f.Name.Contains(Name) )
                .Include(f => f.Location)
                .Include(f => f.Type)
                .ToListAsync();
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


    }
}
