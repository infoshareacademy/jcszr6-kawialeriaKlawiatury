using FoodTrakker.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrakker.BusinessLogic.Repository;

namespace FoodTrakker.BusinessLogic.Models
{
    public class FoodTruck : Iindexable
    {
        public int Id { get; internal set; }
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }
        [MinLength(150)]
        [MaxLength(1000)]
        public string Description { get; set; }
        public Location Location { get; set; }
        public FoodTruckType Type { get; set; }
        public int OwnerId { get; set; }

        public void UpdateIndex(int i)
        {
            Id = i;
        }
    }
}
