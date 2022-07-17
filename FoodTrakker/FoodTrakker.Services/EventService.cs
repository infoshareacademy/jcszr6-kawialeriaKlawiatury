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
        private readonly IRepository<Event> _eventRepository;
        public EventService(IRepository<Event> eventRepository)
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


    }
}
