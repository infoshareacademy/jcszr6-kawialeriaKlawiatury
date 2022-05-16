using System;
using FoodTrakker.BusinessLogic;

namespace FoodTrakker.GUI.ConsoleInput
{
    internal class AddingFoodTruck
    {
        
        public void InputNewFoodTruck ()
        {
            FoodTruck newFoodTruck = new FoodTruck();
            
            Console.Clear();
            // jak dodać ID?

            Console.WriteLine("Enter the name of a new Food Truck:");
            newFoodTruck.Name = Console.ReadLine();
       
            Console.WriteLine("\nIn which town it is usually located:"); 
            Console.WriteLine("\n\ton what street?:");
            newFoodTruck.Location.Street = Console.ReadLine();
                        // co z wartościami: ZipCode, StartDate i EndDate

            Console.WriteLine("\nEnter the Owner:");  
            newFoodTruck.Owner.Name = Console.ReadLine();
            // dodawanie ID?;

            Console.Clear();
            Console.WriteLine("To enter type of this FoodTruck, please chose from tle list:");
            // dodanie 'menu' typów FT do wyboru??

            FoodTruckRepository.AddFoodTruck(newFoodTruck);
        }

    }
}
