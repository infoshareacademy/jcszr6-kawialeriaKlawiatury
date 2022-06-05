using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FoodTrakker.BusinessLogic.Models;
using FoodTrakker.BusinessLogic.Repository;

namespace FoodTrakker.GUI
{
    public class DisplayGUI
    {
        private static List<Review> _reviews = DataRepository<Review>.GetData();
        public static void ShowFoodTrucks()
        {
            var foodTrucks = DataRepository<FoodTruck>.GetData();
            Console.Clear();
            foreach (var foodTruck in foodTrucks)
            {
                var reviews = _reviews.FindAll(r => r.FoodTruckId == foodTruck.Id );
                var foodTruckMessage =
                    $"Id: {foodTruck.Id} Name: {foodTruck.Name}, Type {foodTruck.Type.Name}, Located: {foodTruck.Location.City}, Street: {foodTruck.Location.Street}";
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{foodTruckMessage}");
                Console.ForegroundColor = ConsoleColor.White;
                foreach (var review in reviews)
                {
                    Console.WriteLine(review.ToString());
                }
                Console.WriteLine();
            }
            Console.WriteLine("Press Enter for main menu!");
            string decision = Console.ReadLine().ToLower();
            MainMenu.Create();
        }

        public static void ShowEvents()
        {
            var events = DataRepository<Event>.GetData();
            Console.Clear();
            foreach (var eEvent in events)
            {
                var eventMessage =
                    $"Id: {eEvent.Id} Name: {eEvent.Name}, Located {eEvent.Location}, Description: {eEvent.Description}\nStarts: {eEvent.StartDate}\nEnds: {eEvent.EndDate}";
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{eventMessage}\nFood Trucks:");
                Console.ForegroundColor = ConsoleColor.White;
                if (eEvent.FoodTrucks != null)
                {
                    foreach (var foodTruck in eEvent.FoodTrucks)
                    {
                        Console.WriteLine($"Name: {foodTruck.Name},Type: {foodTruck.Type.Name},\nDescription: {foodTruck.Description}");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("Press Enter for main menu!");
            string decision = Console.ReadLine().ToLower();
            MainMenu.Create();
        }

    }
}
