

using FoodTrakker.Core.LinkingClasses;

namespace FoodTrakker.Core.Model
{
    public class Event : Iindexable<int>
    {
       
        public int Id { get; set; }
        public string Name { get;set; } 
        public string Description { get;set; }
        public string Location { get;set; }
        public DateTime StartDate { get;set; }    
        public DateTime EndDate { get; set; }
        public string? OwnerId { get; set; }
        public ICollection<FoodTruckEvent>? FoodTruckEvents { get; set; }
        
    }
}
