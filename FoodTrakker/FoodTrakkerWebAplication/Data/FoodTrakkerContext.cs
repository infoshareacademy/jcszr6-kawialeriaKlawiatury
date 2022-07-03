using FoodTrakker_WebBusinessLogic.Model;
using Microsoft.EntityFrameworkCore;

namespace FoodTrakkerWebAplication.Data
{
    public class FoodTrakkerContext : DbContext
    {
        public FoodTrakkerContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder
                .UseSqlServer("Server=DESKTOP-NDVQDSJ\\SQLEXPRESS;Database=FoodTrakkerDb;Trusted_Connection=True;MultipleActiveResultSets=True;");
        }
        public DbSet<Event> Events { get; set; }
        public DbSet<FoodTruck> FoodTrucks { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<FoodTruckType> FoodTruckTypes { get; set; }

       
    }
}
