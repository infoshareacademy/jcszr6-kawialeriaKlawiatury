using FoodTrakker_WebBusinessLogic.Model;


namespace FoodTrakker.BusinessLogic.Repository
{
    public class UserRepository : MockRepository<User>
    {
        public UserRepository():base("User.json")
        {
        }
    }
}
