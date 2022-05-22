using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using FoodTrakker.BusinessLogic;
using FoodTrakker.BusinessLogic.Models;
using FoodTrakker.BusinessLogic.Repository;

namespace FoodTrakker.GUI
{
    public class FindEventGUI
    {
        public static void FindEventMenu()
        {
            var eventList = DataRepository<Event>.GetData();
            var foodTruckList = DataRepository<FoodTruck>.GetData();

            var foodTruckOptions = new List<Option>();

            foreach (var foodTruck in foodTruckList)
            {
                var message = $"{foodTruck.Id}. {foodTruck.Name} located: {foodTruck.Location.City} ";
                foodTruckOptions.Add(new Option(name: message, () => EventsMenuGUI(foodTruck.Id)));
            }


            int index = 0;
            if (foodTruckOptions.Count > 0)
            {

                WriteMenuFindEvent(foodTruckOptions, foodTruckOptions[index]);
                ConsoleKeyInfo keyinfo;
                do
                {
                    keyinfo = Console.ReadKey();

                    // Handle each key input (down arrow will write the menu again with a different selected item)
                    if (keyinfo.Key == ConsoleKey.DownArrow)
                    {
                        if (index + 1 < foodTruckOptions.Count)
                        {
                            index++;
                            WriteMenuFindEvent(foodTruckOptions, foodTruckOptions[index]);
                        }
                    }
                    if (keyinfo.Key == ConsoleKey.UpArrow)
                    {
                        if (index - 1 >= 0)
                        {
                            index--;
                            WriteMenuFindEvent(foodTruckOptions, foodTruckOptions[index]);
                        }
                    }
                    // Handle different action for the option
                    if (keyinfo.Key == ConsoleKey.Enter)
                    {
                        foodTruckOptions[index].Selected.Invoke();
                        index = 0;
                        break;
                    }
                }
                while (keyinfo.Key != ConsoleKey.X);
            }            
            else
                Console.WriteLine("List is empty");


        }

        private static void EventsMenuGUI(int Id)
        {
            var eventList = FindEvent.FindEventsForFoodTruck(Id);
            var foodTruck = DataRepository<FoodTruck>.GetData().First(f => f.Id == Id);
            var messages = new List<string>();
            Console.Clear();

            var optionsNewOptions = new List<Option>
            {
                new Option("Find events for another food truck", () => FindEventMenu()),
                new Option("Exit to main menu", () => WriteTemporaryMessage("Exists to main menu!"))
            };


            foreach (var @event in eventList)
            {
                var message = $"----------------------------------" +
                              $"\nThe event list for {foodTruck.Name}:\n" +
                              $"Event name: {@event.Name} in {@event.Location}\n" +
                              $"Description: {@event.Description}\n" +
                              $"Starts at: {@event.StartDate}\n" +
                              $"Ends at: {@event.EndDate}";
                optionsNewOptions.Add(new Option(message, () => EventsMenuGUI(Id)));
            }

            int index = 0;
            WriteMenuFindEvent(optionsNewOptions, optionsNewOptions[index]);
            ConsoleKeyInfo keyinfo;
            
            do
            {
                keyinfo = Console.ReadKey();

                // Handle each key input (down arrow will write the menu again with a different selected item)
                if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 < optionsNewOptions.Count)
                    {
                        index++;
                        WriteMenuFindEvent(optionsNewOptions, optionsNewOptions[index]);
                    }
                }
                if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        WriteMenuFindEvent(optionsNewOptions, optionsNewOptions[index]);
                    }
                }
                // Handle different action for the option
                if (keyinfo.Key == ConsoleKey.Enter)
                {
                    optionsNewOptions[index].Selected.Invoke();
                    index = 0;
                    break;
                }
            }
            while (keyinfo.Key != ConsoleKey.X);

            


        }

        private static void WriteMenuFindEvent(List<Option> options, Option selectedOption)
        {
            Console.Clear();
            Console.WriteLine("Please select for which food truck would You like to find an event:\n ");
            foreach (Option option in options)
            {
                if (option == selectedOption)
                {
                    Console.Write("> ");
                }
                else
                {
                    Console.Write(" ");
                }

                Console.WriteLine(option.Name);
            }
        }

        static void WriteTemporaryMessage(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            Thread.Sleep(3000);
        }
    }
}
