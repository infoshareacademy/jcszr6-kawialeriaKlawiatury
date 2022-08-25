using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Globalization;

namespace FoodTrakker.Services.DTOs
{
    public class ReviewDto 
    {
       
        public int Id { get; set; }
        public int? FoodTruckId { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [IntegerValidator(MinValue = 1, MaxValue = 10)]
        public int Rating { get; set; }
        
       
    }
}
