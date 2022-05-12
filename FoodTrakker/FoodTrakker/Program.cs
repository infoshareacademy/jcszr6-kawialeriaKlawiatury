using System;
using System.Collections.Generic;
using FoodTrakker.BusinessLogic;
using FoodTrakker.BusinessLogic.Models;

namespace FoodTrakker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var events = new EventRepository();

            var event1 = new Event();

            var event2 = new Event();

            var event3 = new Event();

            event1.ID = 1;
            event2.ID = 2;
            event3.ID = 3;

            
            var foodTruck1 = new FoodTruck
            {
                ID = 1
            };

            var foodTruck2 = new FoodTruck
            {
                ID = 2
            };

            var foodTruck3 = new FoodTruck
            {
                ID = 3
            };

            events.AddEvent(event1);
            events.AddEvent(event2);
            events.AddEvent(event3);

            event1.FoodTrucks = new List<FoodTruck>();
            event3.FoodTrucks = new List<FoodTruck>();
            event2.FoodTrucks = new List<FoodTruck>();

            event1.FoodTrucks.Add(foodTruck1);
            event1.FoodTrucks.Add(foodTruck2);

            event2.FoodTrucks.Add(foodTruck1);

            event3.FoodTrucks.Add(foodTruck2);
            event3.FoodTrucks.Add(foodTruck1);



            var foundEvents = FindEvent.FindEventsForFoodTruck(foodTruck3, events.GetAllEvents());
            foreach (var eEvent in foundEvents)
            {
                Console.WriteLine(eEvent.ID);
            }
        }
    }
}
