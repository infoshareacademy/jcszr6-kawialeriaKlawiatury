using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrakker.BusinessLogic.ConsoleInput
{
    internal class AddingReview
    {
        public string reviewedTruckName;

        public void AddReviewTitle(string reviewTitle)
        {
            Console.WriteLine("Enter name of FoodTruck you'd like to share your review on:");
            reviewedTruckName = Console.ReadLine();

            reviewTitle = ($"{ /*użytkownik wpisujący recenzję*/}'s review on {reviewedTruckName}.");
        }

        public void TruckRating(int truckRating)
        {
            Console.WriteLine($"Rate chosen Food Truck from 1 to 9," +
                              $"\n\t where:" +
                              $"\n\t\t1 - very bad;" +
                              $"\n\t\t9 - ecstasy of tastes!!");

            int rating;
            bool isTrue = false;
            do
            {
                var ratingParseResult = int.TryParse(Console.ReadLine(), out rating);

                if (!ratingParseResult)
                {
                    Console.WriteLine("\nplease enter number from 1 to 9:");
                }
                else if (ratingParseResult && rating < 1)
                {
                    Console.WriteLine("Common, it cant' be that bad. Give it at least 1:");
                }
                else if (ratingParseResult && rating > 9)
                {
                    Console.WriteLine(
                        "I envy you  experiencing this culinary heaven, but let's try to keep on our grading scale;)");
                }
                else
                {
                    rating = truckRating;
                    Console.WriteLine("thanks for rating this Food Truck!");
                }
            } while (!isTrue);
        }

        public void AddReviewDescription(string reviewDescription)
        {
            Console.WriteLine("Enter your review:");
            reviewDescription = Console.ReadLine();
        }



    }
}
