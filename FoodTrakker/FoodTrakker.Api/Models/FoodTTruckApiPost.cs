using FoodTrakker.BusinessLogic.Models;

namespace FoodTrakker.Api.Models
{
    public class FoodTTruckApiPost
    {
        public ICollection<Review> Reviews { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LocationId { get; set; }
        public Location? Location { get; set; }
        public int TypeId { get; set; }
        public FoodTruckType? Type { get; set; }
        public string? OwnerId { get; set; }
    }
}
