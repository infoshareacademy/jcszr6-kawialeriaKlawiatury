using System;
using System.Collections.Generic;
using System.Text;
using FoodTrakker_WebBusinessLogic.Model;


namespace FoodTrakker.BusinessLogic.Repository
{
    public class FoodTruckRepository : MockRepository<FoodTruck>
    {
        public FoodTruckRepository():base("FoodTrucks.json")
        {
        }

    }
}
