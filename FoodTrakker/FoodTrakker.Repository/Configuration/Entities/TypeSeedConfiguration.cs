using FoodTrakker.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrakker.Repository.Configuration.Entities
{
    public class TypeSeedConfiguration : IEntityTypeConfiguration<FoodTruckType>
    {
        public void Configure(EntityTypeBuilder<FoodTruckType> builder)
        {
            builder.HasData(
                new FoodTruckType
                {
                    Id = 1,
                    Name = "Polish"
                },
                new FoodTruckType
                {
                    Id = 2,
                    Name = "German"
                },
                new FoodTruckType
                {
                    Id = 3,
                    Name = "American"
                },
                new FoodTruckType
                {
                    Id = 4,
                    Name = "Italian"
                },
                new FoodTruckType
                {
                    Id = 5,
                    Name = "Mexican"
                },
                new FoodTruckType
                {
                    Id = 6,
                    Name = "Beverages"
                },
                new FoodTruckType
                {
                    Id = 7,
                    Name = "Drinks"
                },
                new FoodTruckType
                {
                    Id = 8,
                    Name = "Fast Food"
                },
                new FoodTruckType
                {
                    Id = 9,
                    Name = "Würst"
                },
                new FoodTruckType
                {
                    Id = 10,
                    Name = "Fusion"
                },
                new FoodTruckType
                {
                    Id = 11,
                    Name = "Regional"
                },
                new FoodTruckType
                {
                    Id = 12,
                    Name = "Midterranean"
                },
                new FoodTruckType
                {
                    Id = 13,
                    Name = "Indian"
                },
                new FoodTruckType
                {
                    Id = 14,
                    Name = "Spanish"
                }
                );
        }
    }
}
