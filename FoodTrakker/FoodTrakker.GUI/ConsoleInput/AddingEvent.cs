using System;
using FoodTrakker.BusinessLogic;
using FoodTrakker.BusinessLogic.Models;

namespace FoodTrakker.GUI.ConsoleInput
{
    internal class AddingEvent
    {

        public void AddNewEvent()
        {
            Event newEvent = new Event();

            Console.Clear();
            Console.WriteLine("Please specify the name of the Event you wish to add:\n");
            newEvent.Name = Console.ReadLine();

            Console.Clear();
            Console.WriteLine($"\nPlease describe {newEvent.Name} in few sentences.\n");
            newEvent.Description = Console.ReadLine();

            Console.Clear();
            Console.WriteLine($"\nEnter the location of the {newEvent.Name}:"); 
            newEvent.Location = Console.ReadLine();

            //jak przypisać Startdate i EndDate może jakieś API z kalendarzem?
            Console.Clear();
            Console.WriteLine($"\nWhen does the {newEvent.Name} start?\n");
            newEvent.StartDate = DateTime.????;

            Console.Clear();
            Console.WriteLine($"\nWhen does it end?\n");
            newEvent.EndDate = DateTime.???;

            EventRepository.AddEvent(newEvent);
        }
    }
}
