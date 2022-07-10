using FoodTrakker.Core.LinkingClasses;
using FoodTrakker.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace FoodTrakker.Repository.Data
{
    public class FoodTrakkerContext : DbContext
    {
        public FoodTrakkerContext(DbContextOptions<FoodTrakkerContext> options)
        : base(options)
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

        public DbSet<TypeFT> Types { get; set; }
        public DbSet<FoodTruckEvent> FoodTruckEvents { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FoodTruckEvent>()
                .HasKey(fe => new { fe.FoodTruckId, fe.EventId });
            modelBuilder.Entity<FoodTruckEvent>()
                .HasOne(fe => fe.FoodTruck)
                .WithMany(f => f.FoodTruckEvents)
                .HasForeignKey(fe=> fe.FoodTruckId);
            modelBuilder.Entity<FoodTruckEvent>()
                .HasOne(fe => fe.Event)
                .WithMany(e=>e.FoodTruckEvents)
                .HasForeignKey(fe => fe.EventId);
        }
    }
}
