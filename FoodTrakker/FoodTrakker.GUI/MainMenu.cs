using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using FoodTrakker.GUI.ConsoleInput;
using Colorful;
using Console = Colorful.Console;

namespace FoodTrakker.GUI
{
    public class MainMenu
    {
        private static List<Option> _options;
        public static void Create()
        {
            _options = new List<Option>()
            {
                new Option("Show FoodTruck", () => DisplayGUI.ShowFoodTrucks()),
                new Option("Show Events", () => DisplayGUI.ShowEvents()),
                new Option("Add", () => MainMenu.Add()),
                new Option("Find", () => MainMenu.Find()),
                new Option("Edit", () => MainMenu.Edit()),
                new Option("---------------------", () => MainMenu.Create()),
                new Option("Save", () => FileManagementGUI.Save()),
                new Option("Load", () => FileManagementGUI.Load()),
                new Option("Delete", () => FileManagementGUI.Delete()),
                new Option("Exit", () => Environment.Exit(0)),
            };
            PrintMenu(_options);
        }

        private static void Edit()
        {
            _options = new List<Option>()
            {
                new Option("Edit FoodTruck", () => UpdateFoodTruck.FoodTruckUpdate()),//Metoda Natalii
                new Option("Edit Event",()=> UpdateEvent.EventUpdate()),
                new Option("Edit Review",()=> UpdateReview.ReviewUpdate()),
                new Option("---------------------", () => MainMenu.Edit()),
                new Option("Main Menu", () => MainMenu.Create()),
            };
            PrintMenu(_options);
        }


        private static void Add()
        {
            _options = new List<Option>()
            {
                new Option("Add new FoodTruck", () => AddingFoodTruck.AddFoodTruck()),//Metoda Marka
                new Option("Add new Event", () => AddingEvent.AddNewEvent()),//Metoda Marka
                new Option("Add new Review", () =>AddingReview.AddingReviewGui()),//Metoda Marka
                new Option("---------------------", () => MainMenu.Add()),
                new Option("Main Menu", () => MainMenu.Create()),
            };
            PrintMenu(_options);
        }

        private static void Find()
        {
            _options = new List<Option>()
            {
                new Option("Find FoodTruck", () => TruckMenuGUI.TruckMenu()),//Metoda Mateusz
                new Option("Find Event", () => FindEventGUI.FindEventMenu()),//Metoda Pawel
                new Option("Find Review for FoodTruck",()=>FindReviewGUI.FindReviewForFoodTruck()),
                new Option("Find Review by date",()=>FindReviewGUI.FindReviewByDate()),
                new Option("---------------------", () => MainMenu.Find()),
                new Option("Main Menu", () => MainMenu.Create()),
            };
            PrintMenu(_options);
        }

        //private static void CreateMenu()
        //{
        //    _options = new List<Option>()
        //    {
        //        new Option("Show FoodTruck", () => DisplayGUI.ShowFoodTrucks()),
        //        new Option("Find FoodTruck", () => TruckMenuGUI.TruckMenu()),//Metoda Mateusz
        //        new Option("Find Event", () => FindEventGUI.FindEventMenu()),//Metoda Pawel
        //        new Option("Add new FoodTruck", () => AddingFoodTruck.AddFoodTruck()),//Metoda Marka
        //        new Option("Add new Event", () => AddingEvent.AddNewEvent()),//Metoda Marka
        //        new Option("Add new Review", () =>AddingReview.AddingReviewGui()),//Metoda Marka
        //        new Option("Find Review for FoodTruck",()=>FindReviewGUI.FindReviewForFoodTruck()),
        //        new Option("Find Review by date",()=>FindReviewGUI.FindReviewByDate()),
        //        new Option("Edit FoodTruck", () => UpdateFoodTruck.FoodTruckUpdate()),//Metoda Natalii
        //        new Option("Edit Event",()=> UpdateEvent.EventUpdate()),
        //        new Option("Edit Review",()=> UpdateReview.ReviewUpdate()),
        //        new Option("---------------------", () => MainMenu.Create()),
        //        new Option("Save", () => FileManagementGUI.Save()),
        //        new Option("Load", () => FileManagementGUI.Load()),
        //        new Option("Delete", () => FileManagementGUI.Delete()),
        //        new Option("Exit", () => Environment.Exit(0)),
        //    };

        //    PrintMenu(_options);
        //}


        private static void PrintMenu(List<Option> options)
        {
            int index = 0;

            WriteMenu(options, options[index]);
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
        }

        private static void WriteMenu(List<Option> options, Option selectedOption)
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

        static void WriteTemporaryMessage(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            Thread.Sleep(3000);
            WriteMenu(_options, _options.First());
        }

    }

}
