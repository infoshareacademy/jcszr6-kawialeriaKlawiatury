using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace FoodTrakker.Core.Model

{
    
    public class User : IdentityUser, Iindexable
    {
        public int Id { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }

        public string? LastName { get; set; }
        public List<FoodTruck> FavouriteFoodTrucks { get; set; }
        public List<Review> Reviews { get; set; }


    }
}
