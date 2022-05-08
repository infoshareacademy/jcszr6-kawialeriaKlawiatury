using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrakker.BusinessLogic.Models
{
    internal class Event
    {
        public int Id { get;private set; } 
        public string Name { get;set; } 
        public string Description { get;set; }
        public string Location { get;set; } 
        public DateTime StartDate { get;set; }    
        public DateTime EndDate { get; set; }
        public List<FoodTruck>FoodTrucks { get; set; }
    }
}
