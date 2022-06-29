using FoodTrakker_WebBusinessLogic.Model;


namespace FoodTrakker_WebBusinessLogic.Repository
{
    public class UserRepository : MockRepository<User>
    {
        public UserRepository():base("User.json")
        {
        }
    }
}
