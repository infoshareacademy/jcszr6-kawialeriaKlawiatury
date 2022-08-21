
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
    }
}
