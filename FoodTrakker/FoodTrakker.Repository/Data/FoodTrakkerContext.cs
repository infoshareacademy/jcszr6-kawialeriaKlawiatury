using FoodTrakker.Core.LinkingClasses;
using FoodTrakker.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


namespace FoodTrakker.Repository.Data
{
    public class FoodTrakkerContext : IdentityDbContext<User>
    {
        public FoodTrakkerContext(DbContextOptions<FoodTrakkerContext> options)
        : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder
                .UseSqlServer();
        }
        public DbSet<Event> Events { get; set; }
        public DbSet<FoodTruck> FoodTrucks { get; set; }

        //public DbSet<User> Users { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<FoodTruckType> Types { get; set; }
        public DbSet<FoodTruckEvent> FoodTruckEvents { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FoodTrakkerContext).Assembly);

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

            modelBuilder.Entity<User>()              
                .Ignore(u => u.FavouriteFoodTrucks);
            modelBuilder.Entity<User>()
                .Ignore(u => u.Reviews);
            modelBuilder.Entity<User>()
                .HasMany<FoodTruck>(u => u.FavouriteFoodTrucks)
                .WithMany(f => f.Users);

            modelBuilder.Entity<FoodTruck>()
                .HasMany<Review>(f => f.Reviews)
                .WithOne(r => r.FoodTruck)
                .HasForeignKey(r => r.FoodTruckId);
            //modelBuilder.Entity<Review>()
            //   .Ignore(r=>r.FoodTruckId);
            modelBuilder.Entity<Review>()
                .HasOne<User>(r => r.User)
                .WithMany(u => u.Reviews);
                
            modelBuilder.Entity<FoodTruck>()
                .HasIndex(f => f.Name)
                .IsUnique();

        }
    }
}
