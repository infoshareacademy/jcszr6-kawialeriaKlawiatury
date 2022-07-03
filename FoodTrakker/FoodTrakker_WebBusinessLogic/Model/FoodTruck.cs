

namespace FoodTrakker_WebBusinessLogic.Model
{
    public class FoodTruck : Iindexable
    {
        public int Id { get; set; }
 
        public string Name { get; set; }

        public string Description { get; set; }
        public Location Location { get; set; }
        public FoodTruckType Type { get; set; }
        public int OwnerId { get; set; }

        public void UpdateIndex(int i)
        {
            Id = i;
        }
        public override string ToString()
        {
            return $" FoodTruck: Name: {Name},Description: {Description},Location: {Location},Type: {Type}";
        }
    }
}
