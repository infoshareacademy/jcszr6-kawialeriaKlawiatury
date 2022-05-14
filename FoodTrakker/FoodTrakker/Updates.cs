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
            foreach (var foodTruck in foodTrucks)
            {
                if(foodTruck.ID == foodTruckToUpdate.ID)
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
}
