using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
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

        public void GetEventsFromJSON()
        {
            var eventsJson = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "Events.json"));
            var events = JsonSerializer.Deserialize<List<Event>>(eventsJson);
            _events.AddRange(events);
        }

    }
}
