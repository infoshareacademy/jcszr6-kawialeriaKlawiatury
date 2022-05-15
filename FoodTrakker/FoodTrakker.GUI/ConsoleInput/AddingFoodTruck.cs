using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrakker.BusinessLogic.ConsoleInput
{
    internal class AddingFoodTruck
    {
       
        public void AddTruckName (string truckName)
        {
            Console.WriteLine("Enter the name of a new Food Truck:");
            truckName = Console.ReadLine();
        }

        public void AddTruckLocation(string truckLocation)
        {
            Console.WriteLine("enter it's usual location:"); //czy w apce nie powinny być 2 lokazlizacje? (stała i w trakcie eventu)?
            truckLocation = Console.ReadLine();
        }

        public void AddTruckOwner(string truckOwner)
        {
            Console.WriteLine("Enter the Owner:");  //tylko Owner User?
            truckOwner = Console.ReadLine();
        }


    }
}
