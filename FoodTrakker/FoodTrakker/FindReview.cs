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
            foreach (var rev in reviews)
            {
                if (rev.Date.Equals(date))
                {
                    Console.WriteLine(rev);
                }
            }
        }

        public void FindReviewForFoodTruck(int id)
        {
            foreach (var rev in reviews)
            {
                if (rev.FoodTruckId.Equals(id))
                {
                    Console.WriteLine(rev);
                }
            }
        }
    }
}
