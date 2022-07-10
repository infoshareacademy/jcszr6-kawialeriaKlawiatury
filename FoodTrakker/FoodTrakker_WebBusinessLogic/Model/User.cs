using Microsoft.EntityFrameworkCore;

namespace FoodTrakker.Core

{
    [Keyless]
    public class User : Iindexable
    {
        public int Id { get; set; } 
        public string Login { get;set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public List<int> FavouriteFoodTrucksID { get; set; }
        public List<int> ReviewsID { get; set; }
        
        
    }
}
