using System.Collections.Generic;
using System;
using System.ComponentModel.Design.Serialization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using FoodTrakker.BusinessLogic.Models;

namespace FoodTrakker.GUI
{
    public class TruckMenuGUI
    {
        public static List<TruckOption> truckOptions;

        public static void TruckMenu()
        {

            truckOptions = new List<TruckOption>
                {
                    new TruckOption("Find Food Truck by name", () => SearchTruckGUI.SearchTruckByName()),
                    new TruckOption("Find review for a Food Truck", () => FindReviewGUI.FindReviewForFoodTruck()),//Metoda Natalii
                };


            int index = 0;


            WriteMenu(truckOptions, truckOptions[index]);


            ConsoleKeyInfo keyinfo;
            do
            {
                keyinfo = Console.ReadKey();


                if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 < truckOptions.Count)
                    {
                        index++;
                        WriteMenu(truckOptions, truckOptions[index]);
                    }
                }

                if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        WriteMenu(truckOptions, truckOptions[index]);
                    }
                }

                if (keyinfo.Key == ConsoleKey.Enter)
                {
                    truckOptions[index].Selected.Invoke();
                    index = 0;
                }
            } while (keyinfo.Key != ConsoleKey.X);

            Console.ReadKey();

        }

        // Default action of all the truckOptions.
        static void WriteTemporaryMessage(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            Thread.Sleep(3000);
            WriteMenu(truckOptions, truckOptions.First());
        }



        static void WriteMenu(List<TruckOption> options, TruckOption selectedTruckOption)
        {
            Console.Clear();

            foreach (TruckOption option in options)
            {
                if (option == selectedTruckOption)
                {
                    Console.Write("> ");
                }
                else
                {
                    Console.Write(" ");
                }

                Console.WriteLine(option.Name);
            }
        }
    }

    public class TruckOption
    {
        public string Name { get; }
        public Action Selected { get; }

        public TruckOption(string name, Action selected)
        {
            Name = name;
            Selected = selected;
        }
    }

}
