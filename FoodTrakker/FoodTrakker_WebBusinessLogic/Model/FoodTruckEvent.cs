using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrakker_WebBusinessLogic.Model
{
    public class FoodTruckEvent
    {
        public int FoodTruckId { get; set; }
        public FoodTruck FoodTruck { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
