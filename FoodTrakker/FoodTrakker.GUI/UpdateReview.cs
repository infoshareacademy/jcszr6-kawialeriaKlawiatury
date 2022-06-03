using FoodTrakker.BusinessLogic;
using System;
using System.Linq;

namespace FoodTrakker.GUI
{
    internal class UpdateReview
    {
        //public void ReviewUpdate()
        //{
        //    int id;
        //    Console.WriteLine("Enter the id of Review.");
        //    var input = Console.ReadLine();
        //    bool isinputInt = int.TryParse(input, out id);
        //    while (!isinputInt)
        //    {
        //        Console.WriteLine("It isn't a number.");
        //        input = Console.ReadLine();
        //        isinputInt = int.TryParse(input, out id);
        //    }
        //    var reviewsList = ReviewRepository.GetAllReviews();
        //    var review = reviewsList.FirstOrDefault(r => r.ID == id);
        //    if (review == null)
        //    {
        //        Console.WriteLine("Your Review doesn't exist.Please choose Add.");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Write number which property want to change and press enter.");
        //        Console.WriteLine("Press 1 if you want to update the title.");
        //        Console.WriteLine("Press 2 if you want to update description.");
        //        Console.WriteLine("Press 3 if you want to update rating.");
        //        Console.WriteLine("Press Q when you do all changes to quit.");
        //        do
        //        {
        //            var input2 = Console.ReadLine();
        //            if (input2 == "q" || input2 == "Q")
        //            {
        //                // reviewsList.Add(review);
        //                return;
        //            }
        //            int inputAsInt;
        //            bool isinputInt2 = int.TryParse(input2, out inputAsInt);
        //            while (!isinputInt2)
        //            {
        //                Console.WriteLine("It isn't a number. Please enter value from 1 to 3.");
        //                input2 = Console.ReadLine();
        //                isinputInt2 = int.TryParse(input2, out inputAsInt);
        //            }
        //            while (inputAsInt != 1 && inputAsInt != 2 && inputAsInt != 3)
        //            {
        //                Console.WriteLine("You type wrong value.Please select from 1 to 3.");
        //                input2 = Console.ReadLine();
        //                isinputInt2 = int.TryParse(input2, out inputAsInt);
        //            }
        //            if (inputAsInt == 1)
        //            {
        //                review.Title = Console.ReadLine();
        //            }
        //            if (inputAsInt == 2)
        //            {
        //                review.Description = Console.ReadLine();
        //            }
        //            if (inputAsInt == 3)
        //            {
        //                var checkInput = Console.ReadLine();
        //               int intInput;
        //                bool isInputInt = int.TryParse(checkInput, out intInput);
        //                while (!isInputInt)
        //                {
        //                    Console.WriteLine("It isn't a number. Please enter value from 1 to 10.");
        //                    checkInput = Console.ReadLine();
        //                    isInputInt = int.TryParse(checkInput, out intInput);
        //                    review.Rating = intInput;
        //                }
        //                review.Rating = intInput;
        //            }
                 
        //        }
        //       while (true);
                
        //    }
        //}

    }

}
