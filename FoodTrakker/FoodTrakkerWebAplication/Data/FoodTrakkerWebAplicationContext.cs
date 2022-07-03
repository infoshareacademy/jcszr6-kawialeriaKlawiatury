using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FoodTrakker_WebBusinessLogic.Model;

namespace FoodTrakkerWebAplication.Data
{
    public class FoodTrakkerWebAplicationContext : DbContext
    {
        public FoodTrakkerWebAplicationContext (DbContextOptions<FoodTrakkerWebAplicationContext> options)
            : base(options)
        {
        }

        public DbSet<FoodTrakker_WebBusinessLogic.Model.FoodTruck>? FoodTruck { get; set; }
    }
}
