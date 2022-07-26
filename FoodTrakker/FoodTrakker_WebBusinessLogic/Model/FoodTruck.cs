using FoodTrakker.Core.LinkingClasses;

namespace FoodTrakker.Core.Model
{
    public class FoodTruck : Iindexable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Location Location { get; set; }
        public FoodTruckType Type { get; set; }
        public string OwnerId { get; set; }
        public ICollection<FoodTruckEvent> FoodTruckEvents { get; set; }
      
    }
}
