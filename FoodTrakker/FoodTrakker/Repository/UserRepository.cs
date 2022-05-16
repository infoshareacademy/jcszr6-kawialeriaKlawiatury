using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using FoodTrakker.BusinessLogic.Models;


namespace FoodTrakker.BusinessLogic
{
    public class UserRepository
    {
        private static readonly List<User> _users = new List<User>();


        public static List<User> GetAllUsers()
        {
            return _users;
        }

        public static void AddUser(User user)
        {
            _users.Add(user);
        }
    }
}
