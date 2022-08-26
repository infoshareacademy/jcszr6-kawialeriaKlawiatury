using FoodTrakker.Core.Model;
namespace FoodTrakker.Core.LinkingClasses;

    public class MergedList
    {
        
        public FoodTruck foodTruck { get; set; }
        public Review review { get; set; }
        public Location location { get; set; }
        public User user { get; set; }
        
        
    }

