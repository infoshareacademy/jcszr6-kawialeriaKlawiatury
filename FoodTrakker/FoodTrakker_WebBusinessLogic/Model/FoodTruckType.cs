using System.ComponentModel.DataAnnotations;

namespace FoodTrakker_WebBusinessLogic.Model
{
    public class FoodTruckType
    {
        public int Id { get; set; }

		[Display(Name = "Food truck type")]
        public string Name { get; set; }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
