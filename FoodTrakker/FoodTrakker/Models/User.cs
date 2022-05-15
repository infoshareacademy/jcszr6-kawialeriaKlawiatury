using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrakker.BusinessLogic.Models
{
    public class User
    {
        public int Id { get;private set; } 
        public string Login { get;set; }
        private string Password { get; set; }
        public string Name { get; set; }
        public List<FoodTruck> FavouriteFoodTrucks { get; set; }
        public List<Review> Reviews { get; set; }
        
    }
}
