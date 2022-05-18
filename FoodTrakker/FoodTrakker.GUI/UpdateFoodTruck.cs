using FoodTrakker.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrakker.GUI
{
    public class UpdateFoodTruck
    {
        public void FoodTruckUpdate()
        {
            int id;
            Console.WriteLine("Enter the id of FoodTruck.");
            var input = Console.ReadLine();
            bool isinputInt = int.TryParse(input, out id);
            while (!isinputInt)
            {
                Console.WriteLine("It isn't a number.");
                input = Console.ReadLine();
                isinputInt = int.TryParse(input, out id);
            }
            var foodTruckList = FoodTruckRepository.GetAllFoodTrucks();
            var foodTruck = foodTruckList.FirstOrDefault(f => f.ID == id);
            if (foodTruck == null)
            {
                Console.WriteLine("Your FoodTruck doesn't exist.Please choose Add.");
            }
            else
            {
                char input2;
                do
                {
                    Console.WriteLine("Write number which property want to change and press enter.");
                    Console.WriteLine("Press 1 to update name of FoodTruck.");
                    Console.WriteLine("Press 2 to update description of FoodTruck.");
                    Console.WriteLine("Press 3 to update location of FoodTruck.");
                    Console.WriteLine("Press 4 to update the owner.");

                    var input3 = Console.ReadLine();
                    int inputAsInt;
                    bool isinputInt2 = int.TryParse(input3, out inputAsInt);
                    while (!isinputInt2)
                    {
                        Console.WriteLine("It isn't a number. Please enter value from 1 to 4.");
                        input3 = Console.ReadLine();
                        isinputInt2 = int.TryParse(input3, out inputAsInt);
                    }
                    while (inputAsInt != 1 && inputAsInt != 2 && inputAsInt != 3 && inputAsInt != 4)
                    {
                        Console.WriteLine("You type wrong value.Please select from 1 to 4.");
                        input3 = Console.ReadLine();
                        isinputInt2 = int.TryParse(input3, out inputAsInt);
                    }
                    if(inputAsInt == 1)
                    {
                        foodTruck.Name = Console.ReadLine();
                    }
                    if(inputAsInt == 2)
                    {
                        foodTruck.Description = Console.ReadLine();
                    }
                    if(inputAsInt == 3)
                    {
                       // foodTruck.Location = Console.ReadLine();
                    }
                    if(inputAsInt == 4)
                    {
                        foodTruck.Owner = new BusinessLogic.Models.User
                        {
                            Name = Console.ReadLine()

                        };
                    }
                    Console.WriteLine("If it is all your changes, please press Q to quit.");
                    input2 = Console.ReadKey().KeyChar;
                    Console.ReadLine();
                }
                while (input2 != 'q' && input2 != 'Q');
                if(input2 == 'q' || input2 == 'Q')
                {
                   // foodTruckList.Add(foodTruck);
                    return;
                }
            }


        }
    }
}
