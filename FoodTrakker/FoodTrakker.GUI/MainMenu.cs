using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace FoodTrakker.GUI
{
    public class MainMenu
    {
        private static List<Option> _options;
        public static void Create()
        {
            _options = new List<Option>()
            {
                new Option("Find FoodTruck", () => TruckMenuGUI.TruckMenu()),//Metoda Mateusz
                new Option("Find Event", () => FindEventGUI.FindEventMenu()),//Metoda Pawel
                new Option("Edit FoodTruck", () => WriteTemporaryMessage("")),//Metoda Natalii
                new Option("Add new FoodTruck", () => WriteTemporaryMessage("")),//Metoda Marka
                new Option("Add new Event", () => WriteTemporaryMessage("")),//Metoda Marka
                new Option("Add new Review", () => WriteTemporaryMessage("")),//Metoda Marka
                new Option("Exit", () => Environment.Exit(0)),
            };

            int index = 0;


            WriteMenu(_options, _options[index]);


            ConsoleKeyInfo keyinfo;
            do

            {
                keyinfo = Console.ReadKey();


                if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 < _options.Count)
                    {
                        index++;
                        WriteMenu(_options, _options[index]);
                    }
                }

                if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        WriteMenu(_options, _options[index]);
                    }
                }

                if (keyinfo.Key == ConsoleKey.Enter)
                {
                    _options[index].Selected.Invoke();
                    index = 0;
                    break;
                }

            } while (keyinfo.Key != ConsoleKey.X);

            Console.ReadKey();


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
