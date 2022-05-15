using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrakker.BusinessLogic
{
    internal class Updates
    {
        private readonly List<FoodTruck> foodTrucks = new List<FoodTruck>();

        public void Update(FoodTruck foodTruckToUpdate)
        {
            var foodTruck = foodTrucks.FirstOrDefault(f => f.ID == foodTruckToUpdate.ID);
            if (foodTruck == null)
            {
                Console.WriteLine("Your FoodTruck doesn't exist.Please choose Add. ");
            }
            else
            {
                foodTruck.Owner = foodTruckToUpdate.Owner;
                foodTruck.Type = foodTruckToUpdate.Type;
                foodTruck.Description = foodTruckToUpdate.Description;
                foodTruck.Location = foodTruckToUpdate.Location;
                foodTruck.Name = foodTruckToUpdate.Name;
            }


        }
    }
}
