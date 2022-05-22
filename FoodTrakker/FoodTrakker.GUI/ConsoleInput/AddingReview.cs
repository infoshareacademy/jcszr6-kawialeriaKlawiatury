using System;
using FoodTrakker.BusinessLogic;
using FoodTrakker.BusinessLogic.Models;


namespace FoodTrakker.GUI.ConsoleInput
{
    internal class AddingReview
    {
        public void AddReviewTitle() //zmienia stan czy nie
        {
            //jak pobrać ID FT do ktorego chcemy dodać opinię?  Jak dodać autora?
            Review newReview = new Review();

            Console.Clear();
            /*Console.WriteLine("Enter name of FoodTruck you'd like to share your review on:");
            reviewedTruck. = Console.ReadLine();*/

          //  newReview.Title = (/*$"{ //użytkownik wpisujący recenzję/}'s review on {//FT recenzjonowany}."*/);


            Console.Clear();
            Console.WriteLine("Enter your review:");
            newReview.Description = Console.ReadLine();


            Console.Clear();
            Console.WriteLine($"Rate chosen Food Truck from 1 to 9," +
                              $"\n\t where:" +
                              $"\n\t\t1 - very bad;" +
                              $"\n\t\t9 - ecstasy of tastes!!");

            GiveRate(newReview);

            Console.Clear();


            ReviewRepository.AddReview(newReview);
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
                    Console.WriteLine("\n\tplease enter number from 1 to 9:");
                }
                else if (ratingParseResult && rating < 1)
                {
                    Console.WriteLine("\n\tCommon, it cant' be that bad. Give it at least 1:");
                }
                else if (ratingParseResult && rating > 9)
                {
                    Console.WriteLine(
                        "\n\tI envy you  experiencing this culinary heaven, but let's try to keep on our grading scale;");
                }
                else
                {
                    newReview.Rating = rating; //czy umieszczenie tego tutaj nie jest błędem logicznym?
                    Console.WriteLine("\n\n\tThanks for rating this Food Truck!");
                }
            } while (!isValid);
        }
    }
}
