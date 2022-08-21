using System;
using System.Collections.Generic;
using System.Text;
using FoodTrakker.BusinessLogic.Models;

namespace FoodTrakker.BusinessLogic.Repository
{
    public class EventRepository : MockRepository<Event>
    {
        public EventRepository():base("Events.json")
        {
        }

    }
}
