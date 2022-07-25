
using FoodTrakker.Core.LinkingClasses;

namespace FoodTrakker.Services.DTOs
{
    public class EventDto 
    {
       
        public int Id { get; set; }
        public string Name { get;set; } 
        public string Description { get;set; }
        public string Location { get;set; }
        public DateTime StartDate { get;set; }    
        public DateTime EndDate { get; set; }
        public ICollection<FoodTruckEvent> FoodTruckEvents { get; set; }

    }
}
