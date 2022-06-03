using FoodTrakker.BusinessLogic.Models;
using FoodTrakker.BusinessLogic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace FoodTrakker.BusinessLogic
{
    internal class FindReview
    {
        public List<Review> FindReviewByDate(string date)
        {
            DateTime dateTime = Convert.ToDateTime(date);

            var reviewList = DataRepository<Review>.GetData();
            var reviewsByDate = reviewList.Where(r => r.Date == dateTime).ToList();
            return reviewsByDate;

        }
        public List<Review> FindReviewForFoodTruck(int id)
        {

            var reviewList = DataRepository<Review>.GetData();
            var reviewsByFoodTruckId = reviewList.Where(r => r.FoodTruckId == id).ToList();
            return reviewsByFoodTruckId;
        }
    }
}

