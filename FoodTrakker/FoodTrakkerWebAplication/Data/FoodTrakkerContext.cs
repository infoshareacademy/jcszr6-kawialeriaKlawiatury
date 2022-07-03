using FoodTrakker_WebBusinessLogic.Model;
using Microsoft.EntityFrameworkCore;

namespace FoodTrakkerWebAplication.Data
{
    public class FoodTrakkerContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<FoodTruck> FoodTrucks { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<FoodTruckType> FoodTruckTypes { get; set; }
    }
}
