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
        private static List<Event> _events = DataRepository<Event>.GetData();
        private static List<FoodTruck> _foodTrucks = DataRepository<FoodTruck>.GetData();

        public static void FindEventMenu()
        {
            var foodTruckOptions = new List<Option>();

            foreach (var foodTruck in _foodTrucks)
            {
                var message = $"{foodTruck.Id}. {foodTruck.Name} located: {foodTruck.Location.City} ";
                foodTruckOptions.Add(new Option(name: message, () => EventsMenuGUI(foodTruck.Id)));
            }

            if (foodTruckOptions.Count > 0)
            {
                PrintMenu(foodTruckOptions);
            }
            else
            {
                Console.WriteLine("No food trucks available");
                Thread.Sleep(3000);
                MainMenu.Create();
            }
        }

        private static void EventsMenuGUI(int Id)
        {
            var search = new FindEvent();
            var eventList = search.FindEventsForFoodTruck(Id);
            var foodTruck = _foodTrucks.First(f => f.Id == Id);
            var messages = new List<string>();
            Console.Clear();

            var eventOptions = new List<Option>
            {
                new Option("Find events for another food truck", () => FindEventMenu()),
                new Option("Exit to main menu", () => MainMenu.Create()) 
            };

            foreach (var @event in eventList)
            {
                var message = $"----------------------------------" +
                              $"\nThe event list for {foodTruck.Name}:\n" +
                              $"Event name: {@event.Name} in {@event.Location}\n" +
                              $"Description: {@event.Description}\n" +
                              $"Starts at: {@event.StartDate}\n" +
                              $"Ends at: {@event.EndDate}";
                eventOptions.Add(new Option(message, () => EventsMenuGUI(Id)));
            }

            PrintMenu(eventOptions);
        }

        private static void PrintMenu(List<Option> options)
        {
            int index = 0;

            WriteMenuFindEvent(options, options[index]);
            ConsoleKeyInfo keyinfo;
            do
            {
                keyinfo = Console.ReadKey();

                // Handle each key input (down arrow will write the menu again with a different selected item)
                if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 < options.Count)
                    {
                        index++;
                        WriteMenuFindEvent(options, options[index]);
                    }
                }
                if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        WriteMenuFindEvent(options, options[index]);
                    }
                }
                // Handle different action for the option
                if (keyinfo.Key == ConsoleKey.Enter)
                {
                    options[index].Selected.Invoke();
                    index = 0;
                    break;
                }
            }
            while (keyinfo.Key != ConsoleKey.X);
        }


        private static void WriteMenuFindEvent(List<Option> options, Option selectedOption)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Please select for which food truck would You like to find an event:\n ");
            Console.ForegroundColor = ConsoleColor.White;
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
