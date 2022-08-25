using FoodTrakker.Core.LinkingClasses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTrakker.Core.Model
{
    public class FoodTruck : Iindexable<int>
    {
        [Key]
        public int Id { get; set; }
       // [InverseProperty(nameof(Review.FoodTruck))]
        public ICollection<Review> Reviews { get; set; }
        public int? AvgRating { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<User> Users { get; set; }
        public int LocationId { get; set; }
        public Location? Location { get; set; }
        public int TypeId { get; set; }
        public FoodTruckType? Type { get; set; }
        public string? OwnerId { get; set; }
        public ICollection<FoodTruckEvent>? FoodTruckEvents { get; set; }

    }
}
