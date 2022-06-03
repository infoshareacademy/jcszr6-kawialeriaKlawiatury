using FoodTrakker.BusinessLogic;
using FoodTrakker.BusinessLogic.Models;
using FoodTrakker.BusinessLogic.Repository;
using System;
using System.Linq;

namespace FoodTrakker.GUI
{
    public static class FindReviewGUI
    {
        public static void FindReviewByDate()
        {
            Console.WriteLine("Type the date of reviews.");
            var date = Console.ReadLine();
            DateTime dateTime;
            bool isInputDate = DateTime.TryParse(date, out dateTime);
            while(!isInputDate)   
            {
                Console.WriteLine("You type wrong date.");
                date = Console.ReadLine();
                isInputDate = DateTime.TryParse(date, out dateTime);
            }
            var reviewList = DataRepository<Review>.GetData();
            var reviewsByDate = reviewList.Where(r => r.Date == dateTime).ToList();
            foreach (Review review in reviewsByDate)
            {
                Console.WriteLine($"Reviews from {date}: {review}");
            }
            if (reviewsByDate.Count == 0)
            {
                Console.WriteLine("There aren't any reviews.");
            }


        }

        public static void FindReviewForFoodTruck()
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
            var reviewList = DataRepository<Review>.GetData();
            var reviewsByFoodTruckId = reviewList.Where(r => r.FoodTruckId == id).ToList();
            foreach (Review foodTruckReview in reviewsByFoodTruckId)
            {
                Console.WriteLine($"Reviews for FoodTruck are : {foodTruckReview}");
            }
            if (reviewsByFoodTruckId.Count == 0)
            {

                Console.WriteLine("There aren't any reviews.");
            }
        }
    }
}

