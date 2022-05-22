
using System;
using System.Linq;

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
                Console.WriteLine("Write number which property want to change and press enter.");
                Console.WriteLine("Press 1 to update name of FoodTruck.");
                Console.WriteLine("Press 2 to update description of FoodTruck.");
                Console.WriteLine("Press 3 to update location of FoodTruck.");
                Console.WriteLine("Press 4 to update the owner.");
                Console.WriteLine("Press Q when you do all changes to quit.");

                do
                {
                    var input2 = Console.ReadLine();
                    if (input2 == "q" || input2 == "Q")
                    {
                        // foodTruckList.Add(foodTruck);
                        return;
                    }
                    int inputAsInt;
                    bool isinputInt2 = int.TryParse(input2, out inputAsInt);
                    while (!isinputInt2)
                    {
                        Console.WriteLine("It isn't a number. Please enter value from 1 to 4.");
                        input2 = Console.ReadLine();
                        isinputInt2 = int.TryParse(input2, out inputAsInt);
                    }
                    while (inputAsInt != 1 && inputAsInt != 2 && inputAsInt != 3 && inputAsInt != 4)
                    {
                        Console.WriteLine("You type wrong value.Please select from 1 to 4.");
                        input2 = Console.ReadLine();
                        isinputInt2 = int.TryParse(input2, out inputAsInt);
                    }


                    if (inputAsInt == 1)
                    {
                        foodTruck.Name = Console.ReadLine();
                    }
                    if (inputAsInt == 2)
                    {
                        foodTruck.Description = Console.ReadLine();
                    }
                    if (inputAsInt == 3)
                    {
                        // foodTruck.Location = Console.ReadLine();
                    }
                    if (inputAsInt == 4)
                    {
                        foodTruck.Owner = new BusinessLogic.Models.User
                        {
                            Name = Console.ReadLine()

                        };
                    }
                }
                while (true);
            }
        }
    }
}
