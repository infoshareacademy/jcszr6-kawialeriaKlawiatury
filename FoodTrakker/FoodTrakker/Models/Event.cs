using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrakker.BusinessLogic.Models
{
    public class Event : Iindexable
    {
        public int Id { get; set; }
        public string Name { get;set; } 
        public string Description { get;set; }
        public string Location { get;set; }
        public DateTime StartDate { get;set; }    
        public DateTime EndDate { get; set; }
        public List<FoodTruck> FoodTrucks { get; set; }

        public void UpdateIndex(int i)
        {
            Id = i;
        }

        public override string ToString()
        {
            
            return $" Event : {Id},{Name},{Description},{Location},{StartDate},{EndDate}";
        }

        public Event()
        {
            FoodTrucks = new List<FoodTruck>();
        }
    }
}
