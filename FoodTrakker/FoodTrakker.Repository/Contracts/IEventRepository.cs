using FoodTrakker.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrakker.Repository.Contracts
{
    public interface IEventRepository : IRepository<Event, int>
    {
        public Task<List<Event>> GetFullEventInfoAsync();
        public Task<Event> GetFullEventInfoAsync(int Id);
        public Task<List<Event>> GetOwnerEvents(string ownerId);
        public Task<List<FoodTruck>> GetEventFoodTrucks(Event @event);
    }
}
