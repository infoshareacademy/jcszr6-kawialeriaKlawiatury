using FoodTrakker.Core.LinkingClasses;
using FoodTrakker.Core.Model;

namespace FoodTrakker.Services.DTOs
{
    public class FoodTruckDto
    {
        public int Id { get; set; }
        public ICollection<ReviewDto> Reviews { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string OwnerId { get; set; }
        public int LocationId { get; set; }
        public Location? Location { get; set; }
        public int TypeId { get; set; }
        public FoodTruckType? Type { get; set; }
        public ICollection<FoodTruckEvent>? FoodTruckEvents { get; set; }
        public decimal? AvgRating { get; set; }
        public bool HasCurrentUserReview   { get; set; }
        public bool IsAddedToFav { get; set; }
    }

}
