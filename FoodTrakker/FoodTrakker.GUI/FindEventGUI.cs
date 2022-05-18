using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp;
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
                foodTruckOptions.Add(new Option(name: message, () => FindEvent.FindEventsForFoodTruck(foodTruck.Id)));
            }


            int index = 0;
            Program.WriteMenu(foodTruckOptions, foodTruckOptions[index] );

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
                        Program.WriteMenu(foodTruckOptions, foodTruckOptions[index]);
                    }
                }
                if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        Program.WriteMenu(foodTruckOptions, foodTruckOptions[index]);
                    }
                }
                // Handle different action for the option
                if (keyinfo.Key == ConsoleKey.Enter)
                {
                    foodTruckOptions[index].Selected.Invoke();
                    index = 0;
                }
            }
            while (keyinfo.Key != ConsoleKey.X);
        }


    }
}
