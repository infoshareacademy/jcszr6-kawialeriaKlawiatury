using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;

namespace FoodTrakker.Core.Model
{
    public class Review : Iindexable<int>
    {
       
        
        public int Id { get; set; }
        public int? FoodTruckId { get; set; }
       // [ForeignKey("FoodTruckId")]
        //[InverseProperty("Reviews")]
     //   public FoodTruck FoodTruck { get; set; }

        public FoodTruck FoodTruck { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [IntegerValidator(MinValue = 1, MaxValue = 10)]
        public int Rating { get; set; }
        public int AuthorID { get; set; }
        
    

    }
}
