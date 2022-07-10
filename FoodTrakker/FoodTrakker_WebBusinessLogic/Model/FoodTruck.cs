using FoodTrakker.Core.LinkingClasses;

namespace FoodTrakker.Core.Model
{
    public class FoodTruck : Iindexable
    {
        public FoodTruck()
        {
            
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Location Location { get; set; }
        public TypeFT Type { get; set; }
        public int OwnerId { get; set; }
        public ICollection<FoodTruckEvent> FoodTruckEvents { get; set; }
      
    }
}
