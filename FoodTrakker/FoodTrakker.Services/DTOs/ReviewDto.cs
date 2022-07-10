using System;
using System.Globalization;

namespace FoodTrakker.Services.DTOs
{
    public class ReviewDto 
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public int AuthorID { get; set; }
        public int FoodTruckId { get; set; }
       
    }
}
