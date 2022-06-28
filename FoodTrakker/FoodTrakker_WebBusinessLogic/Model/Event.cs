using System;
using System.Collections.Generic;
using FoodTrakker.BusinessLogic.Repository;


namespace FoodTrakker_WebBusinessLogic.Model
{
    public class Event : Iindexable
    {
        public int Id { get; set; }
        public string Name { get;set; } 
        public string Description { get;set; }
        public string Location { get;set; }
        public DateTime StartDate { get;set; }    
        public DateTime EndDate { get; set; }
        public List<int> FoodTrucksId { get; set; }

        public void UpdateIndex(int i)
        {
            Id = i;
        }

        public override string ToString()
        {
            
            return $" Event : {Id},{Name},{Description},{Location},{StartDate},{EndDate}";
        }


    }
}
