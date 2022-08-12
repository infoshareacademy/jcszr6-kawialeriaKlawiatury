using FoodTrakker.Core.LinkingClasses;
using FoodTrakker.Core.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTrakker.Services.DTOs
{
    public class FoodTruckDto
    {
        [Key]
        public int Id { get; set; }
       // [InverseProperty(nameof(ReviewDto.FoodTruck))]
        public ICollection<ReviewDto> Reviews { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string OwnerId { get; set; }
        public int LocationId { get; set; }
        public Location? Location { get; set; }
        public int TypeId { get; set; }
        public FoodTruckType? Type { get; set; }
        public ICollection<FoodTruckEvent>? FoodTruckEvents { get; set; }

    }

}
