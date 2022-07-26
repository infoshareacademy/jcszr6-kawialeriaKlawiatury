using FoodTrakker.Core.LinkingClasses;
namespace FoodTrakker.Services.DTOs
{
    public class EventDto
    {
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<FoodTruckEvent> FoodTruckEvents { get; set; }
    }  
       
}

