using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrakker.BusinessLogic.Models
{
    public class FoodTruckType
    {
        public int Id { get; internal set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return $" Review : {Id},{Name}";
        }
    }
}
