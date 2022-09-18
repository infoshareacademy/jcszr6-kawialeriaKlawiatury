using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrakker.Services.DTOs
{
    public class FoodTruckTypeDto
    {
        public IEnumerable<FoodTruckDto> FoodTrucks { get; set; }
        //public IEnumerable<ReviewDto> FoodTrackReviews { get; set; }
        public IEnumerable<string> FoodTruckTypeName { get; set; }
        //public IEnumerable<string> FoodTruckReviewRate { get; set; }

    }
}
