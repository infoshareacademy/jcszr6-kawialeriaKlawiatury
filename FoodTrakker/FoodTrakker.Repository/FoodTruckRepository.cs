using FoodTrakker.Core.Model;
using FoodTrakker.Repository.Contracts;
using FoodTrakker.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace FoodTrakker.Repository
{
    public class FoodTruckRepository : Repository<FoodTruck, int>, IFoodTruckRepository
    {
        private readonly FoodTrakkerContext _context;
        public FoodTruckRepository(FoodTrakkerContext context) : base(context)
        {
            _context = context;
        }

        //Task<List<FoodTruck>> FindByEventAsync(string EventName)
        //{

        //}
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
        public Task<List<FoodTruck>> FindByTypeAsync(string Type)
        {
            return _context.FoodTrucks.Where(f => f.Type.Name.Contains(Type))
                .Include(f => f.Location)
                .Include(f => f.Type)
                .ToListAsync();
        }

        public Task<List<FoodTruck>> FindFoodTruckAsync(string Name)
        {
            return _context.FoodTrucks.Where(f => f.Name.Contains(Name))
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
        public Task<List<FoodTruck>> GetOwnerFoodTrucks(string ownerId)
        {
            return Task.FromResult(_context.FoodTrucks
                 .Include(f => f.Location)
                 .Include(f => f.Type)
                 .Where(f => f.OwnerId == ownerId)
                 .ToList());
        }
        public async Task<(double,int)> AvgRatingAndReviewCount(int Id)
        {
            double avg = 0;
            var count = await _context.Reviews.CountAsync(r => r.FoodTruckId == Id);
           
            if(count != 0) 
              avg = await _context.Reviews.Where(r => r.FoodTruckId == Id).AverageAsync(r => r.Rating);
           
            return (avg, count);
        }
        
        public async Task<bool> HasFoodTruckReviewFromUser(int foodTruckId, string userId)
        {
            var result = await _context.FoodTrucks.SingleOrDefaultAsync(f => f.Id == foodTruckId &&
            f.Reviews.Any(r => r.UserId.Equals(userId)));
            return result != null;
        }
       public async Task<bool> IsAddedToFav(int id, string userId)
        {
            var resultl = await _context.FoodTrucks.SingleOrDefaultAsync(f => f.Id == id &&
            f.Users.Any(u=>u.Id.Equals(userId)));
            return resultl != null;
        }
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }


        //Task<List<FoodTruck>> IFoodTruckRepository.FindByEventAsync(string Event)
        //{
        //    return _context.FoodTruckEvents.Where(f => f.FoodTruck.FoodTruckEvents.Contains(Event))
        //        .Include(f => f.Location)
        //        .Include(f => f.Type)
        //        .ToListAsync();
        //}

    }
}
