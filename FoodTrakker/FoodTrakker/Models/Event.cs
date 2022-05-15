using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrakker.BusinessLogic.Models
{
    public class Event
    {
        public int ID { get; internal set; }
        public string Name { get;set; } 
        public string Description { get;set; }
        public string Location { get;set; } 
        public DateTime StartDate { get;set; }    
        public DateTime EndDate { get; set; }
    }
}
