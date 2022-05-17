using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrakker.BusinessLogic.Repository;

namespace FoodTrakker.BusinessLogic.Models
{
    public class User : Iindexable
    {
        public int Id { get; internal set; } 
        public string Login { get;set; }
        public string Password { get; private set; }
        public string Name { get; set; }
        public List<int> FavouriteFoodTrucksID { get; set; }
        public List<Review> Reviews { get; set; }
        public void UpdateIndex(int i)
        {
            Id = i;
        }

    }
}
