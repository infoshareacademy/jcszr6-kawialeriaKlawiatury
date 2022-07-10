

namespace FoodTrakker.Core

{
    public class FoodTruckEvent
    {
        public int FoodTruckId { get; set; }
        public FoodTruck FoodTruck { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
