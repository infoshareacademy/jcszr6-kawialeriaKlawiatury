using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using FoodTrakker.BusinessLogic;
using FoodTrakker.BusinessLogic.Models;
using FoodTrakker.BusinessLogic.Repository;



namespace FoodTrakker.GUI.ConsoleInput
{
    public class AddingReview
    {
        private static List<User> _users = DataRepository<User>.GetData();
        private static List<FoodTruck> _foodTrukcs = DataRepository<FoodTruck>.GetData();
        public static void AddingReviewGui()
        {
            var foodTruckList = DataRepository<FoodTruck>.GetData();

            var foodTruckOptions = new List<Option>();

            foreach (var foodTruck in foodTruckList)
            {
                var message = $"{foodTruck.Id}. {foodTruck.Name} located: {foodTruck.Location.City} ";
                foodTruckOptions.Add(new Option(name: message, () => AddReview(foodTruck.Id)));
            }
            if (foodTruckOptions.Count > 0)
            {
                PrintMenu(foodTruckOptions);
            }
            else
            {
                Console.WriteLine("No food trucks available"); //Add method to come back to main menu :-)
            }
        }
        private static void WriteMenuAddReview(List<Option> options, Option selectedOption)
        {
            Console.Clear();
            Console.WriteLine("Please select for which food truck would You like to add review:\n ");
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


        private static void PrintMenu(List<Option> options)
        {
            int index = 0;



            WriteMenuAddReview(options, options[index]);
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
                        WriteMenuAddReview(options, options[index]);
                    }
                }
                if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        WriteMenuAddReview(options, options[index]);
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
        public static void AddReview(int Id) 
        {
             Review newReview = new Review();

            newReview.Date = DateTime.Now;
            var foodTruck = _foodTrukcs.First(f => f.Id == Id);
            newReview.FoodTruckId = Id;

            Console.Clear();
            //Console.WriteLine("Enter name of FoodTruck you'd like to share your review on:");
            //foodTruck.Name = Console.ReadLine();

            newReview.Title = ($"{_users[0].Name}'s review on {foodTruck.Name}."); //w dalszej części wprowadzić dodawanie nazwy zalogowanego usera 


            Console.Clear();
            Console.WriteLine("Enter your review:");
            newReview.Description = Console.ReadLine();


            Console.Clear();
            Console.WriteLine($"Rate chosen Food Truck from 1 to 9," +
                              $"\n\t where:" +
                              $"\n\t\t1 - very bad;" +
                              $"\n\t\t9 - ecstasy of tastes!!");

            GiveRate(newReview);
            
            DataRepository<Review>.AddElement(newReview);

            Console.Clear();
            var message =
                ($"{foodTruck.Name} \n{foodTruck.Description} \n{newReview.Description} \n{newReview.Rating}");
            Console.WriteLine(message);


            Console.Clear();
            Console.WriteLine("Would you like to review another Food truck? (Y/N):");
            string decision = Console.ReadLine().ToLower();
            if (decision == "y")
            {
                AddingReviewGui();
            }
            else
            {
                MainMenu.Create();
            }
        }

        private static void GiveRate(Review newReview)
        {
            int rating;
            bool isValid = false;
            do
            {
                var ratingParseResult = int.TryParse(Console.ReadLine(), out rating);

                if (!ratingParseResult)
                {
                    Console.WriteLine("\n\tplease enter number from 1 to 9: ");
                }
                else if (ratingParseResult && rating < 1)
                {
                    Console.WriteLine("\n\tCome on, it cant' be that bad. Give it at least 1: ");
                }
                else if (ratingParseResult && rating > 9)
                {
                    Console.WriteLine(
                        "\n\tI envy you  experiencing this culinary heaven, but let's try to keep on our grading scale: ");
                }
                else
                {
                    newReview.Rating = rating; //czy umieszczenie tego tutaj nie jest błędem logicznym?
                    Console.WriteLine("\n\n\tThanks for rating this Food Truck!");
                    Thread.Sleep(2000);
                    isValid = true;
                }
            } while (!isValid);
        }
    }
}
