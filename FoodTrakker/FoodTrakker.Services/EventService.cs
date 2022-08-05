using FoodTrakker.Core.LinkingClasses;
using FoodTrakker.Core.Model;
using FoodTrakker.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrakker.Services
{
    public class EventService
    {
        private readonly IEventRepository _eventRepository;
        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<ICollection<Event>> GetEventsAsync()
        {

            return await _eventRepository.GetAsync();
        }

        public async Task<Event> GetEventAsync(int Id)
        {

            return await _eventRepository.GetAsync(Id);

        }

        public async Task<ICollection<Event>> GetFullEventInfoAsync()
        {
            return await _eventRepository.GetFullEventInfoAsync();
        }

        public async Task<Event> GetFullEventInfoAsync(int Id)
        {
            return await _eventRepository.GetFullEventInfoAsync(Id);
        }

        public Task AddEventAsync(Event @event)
        {
            return _eventRepository.AddAsync(@event);
        }

        public List<FoodTruckEvent> AddFoodTrucks(List<int> foodTruckId, Event @event)
        {
            var foodTruckEvents = new List<FoodTruckEvent>();

            foreach (var foodTruck in foodTruckId)
            {
                foodTruckEvents.Add(new FoodTruckEvent()
                {
                    FoodTruckId = foodTruck,
                    Event = @event
                });
            }

            return foodTruckEvents;             
        }
    }
}
