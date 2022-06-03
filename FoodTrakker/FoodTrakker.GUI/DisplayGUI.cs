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
        public static void ShowFoodTrucks()
        {
            var foodTrucks = DataRepository<FoodTruck>.GetData();
            Console.Clear();
            foreach (var foodTruck in foodTrucks)
            {
                var foodTruckMessage =
                    $"Id: {foodTruck.Id} Name: {foodTruck.Name}, Located {foodTruck.Location.City}, Street: {foodTruck.Location.Street}";
                Console.WriteLine(foodTruckMessage);
            }
            Console.WriteLine("To main Menu");
            string decision = Console.ReadLine().ToLower();
            MainMenu.Create();
            
        }

    }
}
