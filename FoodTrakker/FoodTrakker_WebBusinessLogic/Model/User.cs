using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTrakker.Core.Model

{
    
    public class User : IdentityUser, Iindexable<string>
    {
        [Key]
        public override string Id { get => base.Id; set => base.Id = value; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }    
        public ICollection<FoodTruck> FavouriteFoodTrucks { get; set; }
        public List<Review> Reviews { get; set; }


    }
}
