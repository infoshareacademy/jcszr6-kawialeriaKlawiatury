
using FoodTrakker.BusinessLogic.Models;
using FoodTrakker.BusinessLogic.Repository;
using System;
using System.Linq;
using System.Threading;

namespace FoodTrakker.GUI
{
    public static class UpdateFoodTruck
    {
        public static void FoodTruckUpdate()
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
            var foodTruckList = DataRepository<FoodTruck>.GetData();
            var foodTruck = foodTruckList.FirstOrDefault(f => f.Id == id);
            if (foodTruck == null)
            {
                Console.WriteLine("Your FoodTruck doesn't exist.Please choose AddFoodTruck.");
                Thread.Sleep(3000);
                MainMenu.Create();
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
                    Quit(foodTruck, input2);
                    int inputAsInt;
                    bool isinputInt2 = int.TryParse(input2, out inputAsInt);
                    while (!isinputInt2)
                    {
                        Console.WriteLine("It isn't a number. Please enter value from 1 to 4,or Q to quit.");
                        input2 = Console.ReadLine();
                        isinputInt2 = int.TryParse(input2, out inputAsInt);
                        if (input2 == "q" || input2 == "Q")
                        {
                            Quit(foodTruck, input2);
                        }
                    }
                    while (inputAsInt != 1 && inputAsInt != 2 && inputAsInt != 3 && inputAsInt != 4)
                    {
                        Console.WriteLine("You type wrong value.Please select from 1 to 4,or Q to quit.");
                        input2 = Console.ReadLine();
                        isinputInt2 = int.TryParse(input2, out inputAsInt);
                        if (input2 == "q" || input2 == "Q")
                        {
                            Quit(foodTruck, input2);
                        }
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
                        Location location = new Location();
                        Console.WriteLine("Enter the new city");
                        location.City = Console.ReadLine();
                        Console.WriteLine("Enter the new street");
                        location.Street = Console.ReadLine();
                    }
                    if (inputAsInt == 4)
                    {
                        var checkInput = Console.ReadLine();
                        int intInput;
                        bool isInputInt = int.TryParse(checkInput, out intInput);
                        while (!isInputInt)
                        {
                            Console.WriteLine("It isn't a number.");
                            checkInput = Console.ReadLine();
                            isInputInt = int.TryParse(checkInput, out intInput);
                            foodTruck.OwnerId = intInput;
                        }
                        foodTruck.OwnerId = intInput;
                    }
                }
                while (true);
            }
        }

        public static void Quit(FoodTruck foodTruck, string input2)
        {
            if (input2 == "q" || input2 == "Q")
            {
                Console.WriteLine("This is your updated FoodTruck: ");
                Console.WriteLine($"{foodTruck.Name}");
                Console.WriteLine($"{foodTruck.Description}");
                Console.WriteLine($"{foodTruck.Location}");
                Console.WriteLine($"{foodTruck.OwnerId}");
                Thread.Sleep(8000);
                MainMenu.Create();
            }
        }
    }
}
