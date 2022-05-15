using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrakker.BusinessLogic.ConsoleInput
{
    internal class AddingEvent
    {
        public string eventName;
        public string eventDescription;
        public string eventLocation;
        public DateTime TimePeriod;  //??

        public void AddEventName()
        {
            Console.WriteLine("Please specify the name of the Event you wish to add:");
            eventName = Console.ReadLine();
        }

        public void EventDescription()
        {
            Console.WriteLine($"Please describe {eventName} in few sentences.");
            eventDescription = Console.ReadLine();
        }

        public void AddEventLocation()
        {
            Console.WriteLine($"Enter location of {eventLocation}:"); //czy w apce nie powinny być 2 lokazlizacje? (stała i w trakcie eventu)?
            eventLocation = Console.ReadLine();
        }

        public void EventTimePeriod()
        {

        }

    }
}
