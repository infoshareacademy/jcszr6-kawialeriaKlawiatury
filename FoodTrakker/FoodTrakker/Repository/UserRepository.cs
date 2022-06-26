using System;
using System.Collections.Generic;
using System.Text;
using FoodTrakker.BusinessLogic.Models;

namespace FoodTrakker.BusinessLogic.Repository
{
    public class UserRepository : MockRepository<User>
    {
        public UserRepository():base("User.json")
        {
        }

    }
}
