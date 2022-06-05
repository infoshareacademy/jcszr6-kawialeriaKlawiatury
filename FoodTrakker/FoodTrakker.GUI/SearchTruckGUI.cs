using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using FoodTrakker.BusinessLogic;
using FoodTrakker.BusinessLogic.Models;
using FoodTrakker.BusinessLogic.Repository;

namespace FoodTrakker.GUI
{
    public class SearchTruckGUI
    {
        public static void SearchTruckByName()
        {
            Console.WriteLine("\nPlease enter the name of the food truck you are looking for:");
            var name = Console.ReadLine();
            var foodTruck = SearchFoodTruck.Search(name);

            if (foodTruck == null)
            {
                Console.Clear();
                Console.WriteLine("Sorry! We didn`t find a food truck with that name, please try again!");
                SearchTruckByName();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Yey! We found {foodTruck.Name} \n{foodTruck.Description}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nPress enter for main menu");
                string decision = Console.ReadLine().ToLower();
                MainMenu.Create();
            }

        }
        
    }
}
