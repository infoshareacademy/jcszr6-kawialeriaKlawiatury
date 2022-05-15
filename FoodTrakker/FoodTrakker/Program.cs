using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using FoodTrakker.BusinessLogic;
using FoodTrakker.BusinessLogic.Models;

namespace FoodTrakker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var eventsRepo = new EventRepository();
            eventsRepo.GetEventsFromJSON();

            foreach (Event @event in eventsRepo.GetAllEvents())
            {
                Console.WriteLine($"Name: {@event.Name}, Id: {@event.Id}, Location: {@event.Location}");
            }

            foreach (Event @event in eventsRepo.GetAllEvents())
            {
                foreach (FoodTruck foodTruck in @event.FoodTrucks)
                {
                    Console.WriteLine($"Food truck Id: {foodTruck.ID}");
                }
            }

            var foodtruck = new FoodTruck()
            {
                ID = 2
            };

            var listResult = FindEvent.FindEventsForFoodTruck(foodtruck, eventsRepo.GetAllEvents());
            foreach (Event @event in listResult)
            {
                Console.WriteLine($"{@event.Name}");
            }

        }
    }
}
