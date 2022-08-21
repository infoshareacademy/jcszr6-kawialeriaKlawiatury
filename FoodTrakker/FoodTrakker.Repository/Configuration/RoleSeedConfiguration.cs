using FoodTrakker.Repository.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrakker.Repository.Configuration
{
    public class RoleSeedConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "df510c89-042b-4342-a852-b32678f1c1ce",
                    Name = Roles.Administrator,
                    NormalizedName = Roles.Administrator.ToUpper(),
                },
                new IdentityRole
                {
                    Id = "df456c89-021b-4342-a852-b32678f1alec",
                    Name = Roles.Owner,
                    NormalizedName = Roles.Owner.ToUpper(),
                },
                new IdentityRole
                {
                    Id = "df456c69-021b-1234-a852-b32678f1alec",
                    Name = Roles.User,
                    NormalizedName = Roles.User.ToUpper(),
                }
            );

        }
    }
}
