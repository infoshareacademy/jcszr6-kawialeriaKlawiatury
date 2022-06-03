using FoodTrakker.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrakker.GUI
{
    internal class UpdateEvent
    {
    //    public void EventUpdate()
    //    {
    //        int id;
    //        Console.WriteLine("Enter the id of Event.");
    //        var input = Console.ReadLine();
    //        bool isinputInt = int.TryParse(input, out id);
    //        while (!isinputInt)
    //        {
    //            Console.WriteLine("It isn't a number.");
    //            input = Console.ReadLine();
    //            isinputInt = int.TryParse(input, out id);
    //        }
    //        var eventList = EventRepository.GetAllEvents();
    //        var eventToUpdate = eventList.FirstOrDefault(e => e.ID == id);
    //        if (eventToUpdate == null)
    //        {
    //            Console.WriteLine("Your Event doesn't exist.Please choose Add.");
    //        }
    //        else
    //        {

    //            Console.WriteLine("Write number which property want to change and press enter.");
    //            Console.WriteLine("Press 1 to update name of Event.");
    //            Console.WriteLine("Press 2 to update description of Event.");
    //            Console.WriteLine("Press 3 to update location of Event.");
    //            Console.WriteLine("Press 4 to update the List of FoodTrucks.");
    //            Console.WriteLine("Press 5 to update start date.");
    //            Console.WriteLine("Press 6 to update the end date");
    //            Console.WriteLine("Press Q when you do all changes to quit.");
    //            do
    //            {
    //                var input2 = Console.ReadLine();

    //                if (input2 == "q" || input2 == "Q")
    //                {
    //                    // eventList.Add(eventToUpdate);
    //                    return;
    //                }
    //                int inputAsInt;
    //                bool isinputInt2 = int.TryParse(input2, out inputAsInt);
    //                while (!isinputInt2)
    //                {
    //                    Console.WriteLine("It isn't a number. Please enter value from 1 to 6.");
    //                    input2 = Console.ReadLine();
    //                    isinputInt2 = int.TryParse(input2, out inputAsInt);
    //                }
    //                while (inputAsInt != 1 && inputAsInt != 2 && inputAsInt != 3 && inputAsInt != 4 &&
    //                    inputAsInt != 5 && inputAsInt != 6)
    //                {
    //                    Console.WriteLine("You type wrong value.Please select from 1 to 6.");
    //                    input2 = Console.ReadLine();
    //                    isinputInt2 = int.TryParse(input2, out inputAsInt);
    //                }

    //                if (inputAsInt == 1)
    //                {
    //                    eventToUpdate.Name = Console.ReadLine();
    //                }
    //                if (inputAsInt == 2)
    //                {
    //                    eventToUpdate.Description = Console.ReadLine();
    //                }
    //                if (inputAsInt == 3)
    //                {
    //                    //   eventToUpdate.Location = Console.ReadLine();
    //                }
    //                if (inputAsInt == 4)
    //                {
    //                    eventToUpdate.FoodTrucks = new List<FoodTruck>()
    //                    {
    //                        new FoodTruck()
    //                        {
    //                            Name = Console.ReadLine(),
    //                        }
    //                    };

    //                }
    //                if (inputAsInt == 5)
    //                {
    //                    DateTime date = Convert.ToDateTime(Console.ReadLine());
    //                    eventToUpdate.StartDate = date;
    //                }
    //                if (inputAsInt == 6)
    //                {
    //                    DateTime date = Convert.ToDateTime(Console.ReadLine());
    //                    eventToUpdate.EndDate = date;
    //                }

    //            }
    //            while (true);

    //        }


    //    }
    }
}
