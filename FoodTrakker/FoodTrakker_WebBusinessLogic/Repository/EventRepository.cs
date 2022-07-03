
using FoodTrakker_WebBusinessLogic.Model;


namespace FoodTrakker_WebBusinessLogic.Repository
{
    public class EventRepository : MockRepository<Event>
    {
        public EventRepository():base("Events.json")
        {
        }
    }
}
