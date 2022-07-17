using FoodTrakker.Core.Model;

namespace FoodTrakker.Core.LinkingClasses

{
    public class FoodTruckEvent
    {
        public int FoodTruckId { get; set; }
        public FoodTruck FoodTruck { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
