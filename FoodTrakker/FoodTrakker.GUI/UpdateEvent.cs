﻿using FoodTrakker.BusinessLogic;
using FoodTrakker.BusinessLogic.Models;
using FoodTrakker.BusinessLogic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FoodTrakker.GUI
{
    public static class UpdateEvent
    {
        public static void EventUpdate()
        {
            int id;
            Console.WriteLine("Enter the id of Event.");
            var input = Console.ReadLine();
            bool isinputInt = int.TryParse(input, out id);
            while (!isinputInt)
            {
                Console.WriteLine("It isn't a number.");
                input = Console.ReadLine();
                isinputInt = int.TryParse(input, out id);
            }
            var eventList = DataRepository<Event>.GetData();
            var eventToUpdate = eventList.FirstOrDefault(e => e.Id == id);
            if (eventToUpdate == null)
            {
                Console.WriteLine("Your Event doesn't exist.Please choose AddEvent.");
                Thread.Sleep(3000);
                MainMenu.Create();
            }
            else
            {

                Console.WriteLine("Write number which property want to change and press enter.");
                Console.WriteLine("Press 1 to update name of Event.");
                Console.WriteLine("Press 2 to update description of Event.");
                Console.WriteLine("Press 3 to update location of Event.");
                Console.WriteLine("Press 4 to update the List of FoodTrucks.");
                Console.WriteLine("Press 5 to update start date.");
                Console.WriteLine("Press 6 to update the end date");
                Console.WriteLine("Press Q when you do all changes to quit.");
                do
                {
                    var input2 = Console.ReadLine();

                    if (input2 == "q" || input2 == "Q")
                        Quit(eventToUpdate);
                    int inputAsInt;
                    bool isinputInt2 = int.TryParse(input2, out inputAsInt);
                    while (!isinputInt2)
                    {
                        Console.WriteLine("It isn't a number. Please enter value from 1 to 6,or Q to quit.");
                        input2 = Console.ReadLine();
                        isinputInt2 = int.TryParse(input2, out inputAsInt);
                        if (input2 == "q" || input2 == "Q")
                        {
                            Quit(eventToUpdate);
                        }
                    }
                    while (inputAsInt != 1 && inputAsInt != 2 && inputAsInt != 3 && inputAsInt != 4 &&
                        inputAsInt != 5 && inputAsInt != 6)
                    {
                        Console.WriteLine("You type wrong value.Please select from 1 to 6,or Q to quit.");
                        input2 = Console.ReadLine();
                        isinputInt2 = int.TryParse(input2, out inputAsInt);
                        if(input2 == "q" || input2 == "Q")
                        {
                            Quit(eventToUpdate);
                        }
                    }

                    if (inputAsInt == 1)
                    {
                        Press1(eventToUpdate);
                    }
                    if (inputAsInt == 2)
                    {
                        Press2(eventToUpdate);
                    }
                    if (inputAsInt == 3)
                    {
                        Press3(eventToUpdate);

                    }
                    if (inputAsInt == 4)
                    {
                        int input3AsInt = Press4(ref input, ref isinputInt, eventToUpdate);

                    }
                    if (inputAsInt == 5)
                    {
                        Press5(eventToUpdate);
                    }
                    if (inputAsInt == 6)
                    {
                        Press6(eventToUpdate);
                    }
                }
                while (true);
            }
        }

        public static void Press6(Event eventToUpdate)
        {
            var date = Console.ReadLine();
            DateTime dateTime;
            bool isInputDate = DateTime.TryParse(date, out dateTime);
            while (!isInputDate)
            {
                Console.WriteLine("You type wrong date.");
                date = Console.ReadLine();
                isInputDate = DateTime.TryParse(date, out dateTime);
            }
            eventToUpdate.EndDate = dateTime;
        }

        public static void Press5(Event eventToUpdate)
        {
            var date = Console.ReadLine();
            DateTime dateTime;
            bool isInputDate = DateTime.TryParse(date, out dateTime);
            while (!isInputDate)
            {
                Console.WriteLine("You type wrong date.");
                date = Console.ReadLine();
                isInputDate = DateTime.TryParse(date, out dateTime);
            }
            eventToUpdate.StartDate = dateTime;
        }

        public static int Press4(ref string input, ref bool isinputInt, Event eventToUpdate)
        {
            Console.WriteLine("Press 1 to add FoodTruck");
            Console.WriteLine("Press 2 to remove FoodTruck");
            int input3AsInt;
            var input3 = Console.ReadLine();
            bool isinputInt3 = int.TryParse(input3, out input3AsInt);
            while (!isinputInt)
            {
                Console.WriteLine("It isn't a number.");
                input = Console.ReadLine();
                isinputInt = int.TryParse(input3, out input3AsInt);
            }
            while (input3AsInt != 1 && input3AsInt != 2)
            {
                Console.WriteLine("You type wrong value.Please select 1 or 2.");
                input3 = Console.ReadLine();
                isinputInt3 = int.TryParse(input3, out input3AsInt);
            }
            if (input3AsInt == 1)
            {
                int id2;
                Console.WriteLine("Enter the id of FoodTruck.");
                var input5 = Console.ReadLine();
                bool isinputInt5 = int.TryParse(input5, out id2);
                while (!isinputInt5)
                {
                    Console.WriteLine("It isn't a number.");
                    input5 = Console.ReadLine();
                    isinputInt5 = int.TryParse(input5, out id2);
                }
                var foodTruckList = DataRepository<FoodTruck>.GetData();
                var foodTruckToAdd = foodTruckList.FirstOrDefault(f => f.Id == id2);
                eventToUpdate.FoodTrucks.Add(foodTruckToAdd);
                if (foodTruckToAdd == null)
                {
                    Console.WriteLine("You should first add FoodTruck");

                }
            }
            if (input3AsInt == 2)
            {
                int id3;
                Console.WriteLine("Enter the id of FoodTruck.");
                var input6 = Console.ReadLine();
                bool isinputInt6 = int.TryParse(input6, out id3);
                while (!isinputInt6)
                {
                    Console.WriteLine("It isn't a number.");
                    input6 = Console.ReadLine();
                    isinputInt6 = int.TryParse(input6, out id3);
                }
                var foodTruckToRemove = eventToUpdate.FoodTrucks.FirstOrDefault(f => f.Id == id3);
                eventToUpdate.FoodTrucks.Remove(foodTruckToRemove);
                if (foodTruckToRemove == null)
                {
                    Console.WriteLine("This FoodTruck doesn't take place in this Event.");

                }
            }


            return input3AsInt;
        }

        public static void Press3(Event eventToUpdate)
        {
            eventToUpdate.Location = Console.ReadLine();
        }

        public static void Press2(Event eventToUpdate)
        {
            eventToUpdate.Description = Console.ReadLine();
        }

        public static void Press1(Event eventToUpdate)
        {
            eventToUpdate.Name = Console.ReadLine();
        }

        public static void Quit(Event eventToUpdate)
        {
            Console.WriteLine("This is your updated Event");
            Console.WriteLine($"{eventToUpdate.Name}");
            Console.WriteLine($"{eventToUpdate.Description}");
            Console.WriteLine($"{eventToUpdate.Location}");
            Console.WriteLine($"FoodTrucks in Event: ");
            foreach (var item in eventToUpdate.FoodTrucks)
            {
                Console.WriteLine($"{item}");
            }
            Console.WriteLine($"Start Date:{eventToUpdate.StartDate}");
            Console.WriteLine($"End Date:{eventToUpdate.EndDate}");
            Thread.Sleep(10000);
            MainMenu.Create();
        }
    }
}
