﻿using System;
using FoodTrakker.BusinessLogic;
using FoodTrakker.BusinessLogic.Models;
using FoodTrakker.BusinessLogic.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;



namespace FoodTrakker.GUI.ConsoleInput
{
    internal class AddingFoodTruck
    {
        private static List<User> _users = DataRepository<User>.GetData();


        public static void AddFoodTruck()
        {
            FoodTruck newFoodTruck = new FoodTruck();
            var location = new Location();

            Console.Clear();

            Console.WriteLine("Enter the name of a new Food Truck:");
            newFoodTruck.Name = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("\nBoast in a few words what your mobile restaurant offers: ");
            newFoodTruck.Description = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("\n\tIn which town it is usually located:");
            location.City = Console.ReadLine();
            Console.WriteLine("\n\ton what street?:");
            location.Street = Console.ReadLine();
            newFoodTruck.Location = location;

            Console.Clear();
            Console.WriteLine("Are you the owner? (Y/N):");
            string decision = Console.ReadLine().ToLower();
            string owner;
            if (decision == "y")

            {
                owner = _users[0].Name;
            }
            else
            {
                Console.WriteLine($"Please enter the owner of the {newFoodTruck.Name}: ");
                owner = Console.ReadLine();
            }

            Console.Clear();
            var cousineType = new FoodTruckType();
            Console.WriteLine("Enter type of this FoodTruck:");
            cousineType.Name = Console.ReadLine();

            Console.Clear();
            var message =
                ($"The new food truck is {newFoodTruck.Name}. \nUsually it is located in {newFoodTruck.Location}." +
                 $"\n\nHere's a little description: \n\t{newFoodTruck.Description}. \nIt serves {cousineType.Name}" +
                 $"\nIt's owned by {owner}.");
            Console.WriteLine(message);
            Thread.Sleep(2000);
            
            DataRepository<FoodTruck>.AddElement(newFoodTruck);
        }
    }
}
