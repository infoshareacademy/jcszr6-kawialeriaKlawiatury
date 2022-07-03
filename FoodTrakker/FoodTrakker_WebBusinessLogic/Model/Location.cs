using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace FoodTrakker_WebBusinessLogic.Model
{
    public class Location 
    {
		
        public string Street { get; set; }  
        public string City { get; set; }
		[DefaultValue(123456)]
        public int ZIPCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public override string ToString()
        {
            return $"{Street},{City},{ZIPCode},{StartDate},{EndDate}";
        }
    }
   
}
