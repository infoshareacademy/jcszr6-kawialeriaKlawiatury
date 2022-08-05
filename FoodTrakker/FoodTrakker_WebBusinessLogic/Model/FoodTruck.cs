using FoodTrakker.Core.LinkingClasses;
using System.ComponentModel.DataAnnotations;

namespace FoodTrakker.Core.Model
{
    public class FoodTruck : Iindexable<int>
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Location Location { get; set; }
        public FoodTruckType Type { get; set; }
        public int OwnerId { get; set; }
        public ICollection<FoodTruckEvent> FoodTruckEvents { get; set; }
        public ICollection<User> Users { get; set; }
        
    }
}
