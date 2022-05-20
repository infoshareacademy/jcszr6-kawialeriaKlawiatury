using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using FoodTrakker.BusinessLogic.Models;


namespace FoodTrakker.BusinessLogic
{
  public  class  ReviewRepository
    {
        private static readonly List<Review> _reviews = new List<Review>();


        public static List<Review> GetAllReviews()
        {
            _reviews.Add(new Review() { ID = 1,Title= "bla bla",Description = "bla bla bla" });
            return _reviews;
        }

        public static void AddReview(Review review)
        {
            _reviews.Add(review);
        }
    }
}
