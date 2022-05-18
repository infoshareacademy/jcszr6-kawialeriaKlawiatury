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
   public class  EventRepository
    {
        private static readonly List<Event> _events = new List<Event>();


        public static List<Event> GetAllEvents()
        {
            return _events;
        }

        public static void AddEvent(Event eEvent)
        {
            _events.Add(eEvent);
        }
    }
}
