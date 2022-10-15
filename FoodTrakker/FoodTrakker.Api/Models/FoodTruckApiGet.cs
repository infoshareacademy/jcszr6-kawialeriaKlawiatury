using FoodTrakker.Core.Model;

namespace FoodTrakker.Api.Models
{
    public class FoodTruckApiGet
    {
        public int Id { get; set; }
        // [InverseProperty(nameof(Review.FoodTruck))]
        public string Name { get; set; }
        public string Description { get; set; }
        public int LocationId { get; set; }
        public int TypeId { get; set; }
       public string? OwnerId { get; set; }
    }
}
