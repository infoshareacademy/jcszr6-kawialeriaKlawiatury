using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrakker.BusinessLogic.Models;

namespace FoodTrakker.BusinessLogic
{
    internal class FindEvent
    {
        public static List<Event> FindEventsForFoodTruck(FoodTruck foodTruck, List<Event> eventList)
        {
            List<Event> events = new List<Event>();
            foreach (var eEvent in eventList)
            {
                foreach (var eEventFoodTruck in eEvent.FoodTrucks)
                {
                    if (foodTruck.ID == eEventFoodTruck.ID)
                    {
                        events.Add(eEvent);
                        break;
                    }
                }
            }
            return events;
        }
    }
}
