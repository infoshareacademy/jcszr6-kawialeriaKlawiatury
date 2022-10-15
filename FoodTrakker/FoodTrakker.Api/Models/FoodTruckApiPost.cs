using FoodTrakker.BusinessLogic.Models;

namespace FoodTrakker.Api.Models
{
    public class FoodTruckApiPost
    {
       public string Name { get; set; }
        public string Description { get; set; }
        public int LocationId { get; set; }
        public int TypeId { get; set; }
       public string? OwnerId { get; set; }
    }
}
