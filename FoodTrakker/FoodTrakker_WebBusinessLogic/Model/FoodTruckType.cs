using System.ComponentModel.DataAnnotations;

namespace FoodTrakker.Core.Model

{
    public class FoodTruckType : Iindexable
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
