using FoodTrakker.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrakker.BusinessLogic
{
    internal class FindReview
    {
        private readonly List<Review> reviews = new List<Review>();

        public void FindReviewByDate(string dateRev)
        {
            DateTime date = Convert.ToDateTime(dateRev);
            var reviewsByDate = reviews.Where(r => r.Date == date);
            foreach (var revByDate in reviewsByDate)
            {
                Console.WriteLine(revByDate);
            }
        }

        public void FindReviewForFoodTruck(int id)
        {
            var reviewsByFoodTruckId = reviews.Where(r => r.FoodTruckId == id);
            foreach (var revByFoodTruckId in reviewsByFoodTruckId)
            {
                Console.WriteLine(revByFoodTruckId);
            }

        }
    }
}
