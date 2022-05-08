using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrakker.BusinessLogic.Models
{
    internal class Location
    {
        public string Street { get; set; }  
        public string City { get; set; }
        public int ZIPCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
