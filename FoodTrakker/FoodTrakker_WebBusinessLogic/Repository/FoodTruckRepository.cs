using FoodTrakker_WebBusinessLogic.Model;


namespace FoodTrakker_WebBusinessLogic.Repository
{
    public class FoodTruckRepository : MockRepository<FoodTruck>
    {
        public FoodTruckRepository():base("FoodTrucks.json")
        {
        }
    }
}
