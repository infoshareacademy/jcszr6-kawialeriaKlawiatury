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
            List<Event> events = eventList.FindAll(e => e.FoodTrucks.Any(f => f.ID == foodTruck.ID));

            return events;
        }
    }
}
