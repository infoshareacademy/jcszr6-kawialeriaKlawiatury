using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Channels;
using FoodTrakker.BusinessLogic;
using FoodTrakker.BusinessLogic.Models;
using FoodTrakker.BusinessLogic.Repository;
namespace FoodTrakker.GUI
{
    public class SearchTruckGUI
    {
        private static List<Review> _reviews = DataRepository<Review>.GetData();
        public static void SearchTruckByName()
        {
            Console.WriteLine("\nPlease enter the name of the food truck you are looking for:");
            var name = Console.ReadLine();
            var foodTruck = SearchFoodTruck.Search(name);
            if (foodTruck == null)
            {
                Console.WriteLine("Sorry! We didn`t find a food truck with that name. Would you like to try again? y/n");
                string searchDecision = Console.ReadLine().ToLower();
                if (searchDecision == "y")
                {
                    SearchTruckByName();
                }
                if (searchDecision == "n")
                {
                    MainMenu.Create();
                }
            }
            else
            {
                var reviews = _reviews.FindAll(r => r.FoodTruckId == foodTruck.Id);
                Console.WriteLine($"Yey! We found {foodTruck.Name} \n{foodTruck.Description}");
                foreach (var review in reviews)
                {
                    Console.WriteLine(review.ToString());
                }
                Console.WriteLine($"Would you like to find another food truck? y/n");
                string searchDecision = Console.ReadLine().ToLower();
                if (searchDecision == "y")
                {
                    SearchTruckByName();
                }
                if (searchDecision == "n")
                {
                    MainMenu.Create();
                }
            }
        }
    }
}