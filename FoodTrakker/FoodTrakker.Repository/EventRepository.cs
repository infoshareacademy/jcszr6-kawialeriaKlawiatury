
using FoodTrakker.Core;
using FoodTrakker.Core.Model;
using FoodTrakker.Repository.Contracts;
using FoodTrakker.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace FoodTrakker.Repository
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        private readonly FoodTrakkerContext _context;

        public EventRepository(FoodTrakkerContext context) : base(context)
        {
            _context = context;
        }

        public Task<List<FoodTruck>> GetEventFoodTrucks(Event @event)
        {
            var foodTrucks = new List<FoodTruck>();
            foreach (var foodTruckEvent in @event.FoodTruckEvents)
            {
                var foodTruckId = foodTruckEvent.FoodTruckId;
                var foodTruck = _context.FoodTrucks.SingleOrDefault(f => f.Id == foodTruckId);
               
                if (foodTruck != null)
                {
                    foodTrucks.Add(foodTruck);
                }
            }
            return Task.FromResult(foodTrucks);
        }

        public Task<List<Event>> GetFullEventInfoAsync()
        {
            return Task.FromResult(_context.Events
                .Include(ev => ev.FoodTruckEvents)
                .ToList());
        }

        public Task<Event> GetFullEventInfoAsync(int Id)
        {
            return _context.Events
                .Include(ev => ev.FoodTruckEvents)
                .SingleOrDefaultAsync(ev => ev.Id == Id);          
        }

        public Task<List<Event>> GetOwnerEvents(string ownerId)
        {
            return Task.FromResult(_context.Events
                 .Where(f => f.OwnerId == ownerId)
                 .ToList());
        }
    }
}
