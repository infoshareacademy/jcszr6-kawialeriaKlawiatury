using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrakker.BusinessLogic.Models;
using FoodTrakker.BusinessLogic.Repository;

namespace FoodTrakker.BusinessLogic
{
    public class FindEvent
    {
        public static List<Event> FindEventsForFoodTruck(int foodTruckID)
        {
            var eventList = DataRepository<Event>.GetData();
            List<Event> events = eventList.FindAll(e => e.FoodTrucks.Any(f => f.Id == foodTruckID));

            return events;
        }
    }
}

