using System.Collections.Generic;
using System;
using System.ComponentModel.Design.Serialization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using FoodTrakker.BusinessLogic.Models;
using FoodTrakker.BusinessLogic.Repository;
using FoodTrakker.GUI.ConsoleInput;

namespace FoodTrakker.GUI
{
    class Program
    {
        public static List<Option> options;
        static void Main(string[] args)
        {
            WelcomeMessage.Run();
            LoadData.Load();

            options = new List<Option>
            {
                new Option("Find FoodTruck", () => FindTruck("")),
                new Option("Log-In", () =>  WriteTemporaryMessage("You are trying to Log-In")),
                new Option("Create Account", () =>  FindEventGUI.FindEventMenu()),   //WriteTemporaryMessage("You are tryinig to crate account")),
                new Option("Exit", () => Environment.Exit(0)),
            };

            // Set the index of the selected item to be the first
            int index = 0;

            // Write the menu out
            WriteMenu(options, options[index]);

            // Store key info in here
            ConsoleKeyInfo keyinfo;
            do
            {
                keyinfo = Console.ReadKey();

                // Handle each key input (down arrow will write the menu again with a different selected item)
                if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 < options.Count)
                    {
                        index++;
                        WriteMenu(options, options[index]);
                    }
                }
                if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        WriteMenu(options, options[index]);
                    }
                }
                // Handle different action for the option
                if (keyinfo.Key == ConsoleKey.Enter)
                {
                    options[index].Selected.Invoke();
                    index = 0;
                    break;
                }
            }
            while (keyinfo.Key != ConsoleKey.X);

            Console.ReadKey();

        }

        

        // Default action of all the options. 



        static void WriteTemporaryMessage(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            Thread.Sleep(3000);
            WriteMenu(options, options.First());
        }

        static void FindTruck(string locationOfTruck)
        {
            Console.Clear();
            Console.WriteLine("Please enter name of your City to display all avalibe FoodTrucks in area\n");
            locationOfTruck = Console.ReadLine();
            Console.WriteLine($"Thank You! In your location: {locationOfTruck} we found (X) numbers of FoodTrucks ");
            Console.WriteLine("Press any key to back to main menu");
            Console.ReadKey();
            WriteMenu(options, options.First());
        }

        static void LogInOption()
        {
            Console.Clear();


        }



        public static void WriteMenu(List<Option> options, Option selectedOption)
        {
            Console.Clear();

            foreach (Option option in options)
            {
                if (option == selectedOption)
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

    public class Option
    {
        public string Name { get; }
        public Action Selected { get; }

        public Option(string name, Action selected)
        {
            Name = name;
            Selected = selected;
        }
    }

}