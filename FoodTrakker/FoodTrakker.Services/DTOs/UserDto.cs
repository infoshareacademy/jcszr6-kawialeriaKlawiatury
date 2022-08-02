using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrakker.Services.DTOs
{
    public  class UserDto
    {  
        public int Id { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public List<FoodTruckDto> FavouriteFoodTrucks { get; set; }
        public List<ReviewDto> Reviews { get; set; }
    }
}
