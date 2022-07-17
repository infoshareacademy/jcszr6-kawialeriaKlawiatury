using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrakker.BusinessLogic.Models
{
    public class User : Iindexable
    {
        public int Id { get; set; } 
        public string Login { get;set; }
        public string Password { get; private set; }
        public string Name { get; set; }
        public List<int> FavouriteFoodTrucksID { get; set; }
        public List<Review> Reviews { get; set; }
        public override string ToString()
        {
            return $" User: {Id},{Login},{Name},{FavouriteFoodTrucksID},{Reviews}";
        }
        public void UpdateIndex(int i)
        {
            Id = i;
        }
        
    }
}
