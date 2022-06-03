using System.Collections.Generic;
using System;
using System.ComponentModel.Design.Serialization;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using FoodTrakker.BusinessLogic.Models;
using FoodTrakker.BusinessLogic.Repository;
using Newtonsoft.Json.Bson;

namespace FoodTrakker.GUI
{
    public class LogInMenuGUI
    {
        public static List<Option> options;
        private static List<User> _users = DataRepository<User>.GetData();

        private static void UserMenu()
        {
            var userOptions = new List<Option>();

            foreach (var user in _users)
            {
                var message = $"{user.Name}";
                userOptions.Add(new Option(message, () => MainMenu.Create()));
            }

            if (userOptions.Count > 0)
            {
                PrintMenu(userOptions);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No User loaded!");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(2000);
                MainMenu.Create();
            }

        }


        public static void LogIn()
        {
            var loginOptions = new List<Option>();

            options = new List<Option>
                {
                    new Option("Login", () => UserMenu()),
                    new Option("Exit", () => Environment.Exit(0)),
                };

            PrintMenu(options);
        }

        private static void PrintMenu(List<Option> options)
        {
            int index = 0;


            WriteMenu(options, options[index]);


            ConsoleKeyInfo keyinfo;
            do
            {
                keyinfo = Console.ReadKey();


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

                if (keyinfo.Key == ConsoleKey.Enter)
                {
                    options[index].Selected.Invoke();
                    index = 0;
                    break;
                }
            } while (keyinfo.Key != ConsoleKey.X);

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



        static void WriteMenu(List<Option> options, Option selectedNewOption)
        {
            Console.Clear();

            foreach (Option option in options)
            {
                if (option == selectedNewOption)
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

}
