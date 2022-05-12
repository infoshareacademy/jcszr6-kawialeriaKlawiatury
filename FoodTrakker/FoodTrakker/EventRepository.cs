using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrakker.BusinessLogic.Models;

namespace FoodTrakker.BusinessLogic
{
    class EventRepository
    {
        private readonly List<Event> _events = new List<Event>();


        public List<Event> GetAllEvents()
        {
            return this._events;
        }

        public void AddEvent(Event eEvent)
        {
            this._events.Add(eEvent);
        }

    }
}
