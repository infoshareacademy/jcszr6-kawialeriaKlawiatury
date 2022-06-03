using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FoodTrakker.GUI
{
    public class WelcomeMessage
    {
        public static void Run()
        {
            ConsoleSetup();
            AnimationFoodTruck();
            WelcomeString();
        }

        private static void AnimationFoodTruck()
        {
            bool rides = true;
            do
            {
                for (int i = 0; i < 15; i++)
                {
                    Console.Clear();
                    var margin = "".PadLeft(i);
                    Console.WriteLine(margin + @"     +-+-------------+--");
                    Console.WriteLine(margin + @"     | |             |  \");
                    Console.WriteLine(margin + @"     | |             |   \__");
                    Console.WriteLine(margin + @"     | | FoodTrakker |      |");
                    Console.WriteLine(margin + @"     | |             |      |");
                    Console.WriteLine(margin + @"     | |             |      |");
                    Console.WriteLine(margin + @"     | +-------------+      |");
                    Console.WriteLine(margin + @"..ooo|                      |");
                    Console.WriteLine(margin + @"     +-*----*-----*----*----+");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(margin + @"       **  **     **  **");
                    Console.WriteLine(margin + @"        ****       **** ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("  +---+---+---+---+---+---+---+---+---+---+---+---+");
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(200);
                }
                rides = false;
            } while (rides);
        }

        private static void WelcomeString()
        {
            var welcomeMessage = "\n\nWelcome in FoodTrakker App, press any key to enter the main menu.";
            Console.WriteLine(welcomeMessage);
            Thread.Sleep(200);
            Console.WriteLine("Use arrows (UP and Down) to navigate on main menu.");
            Console.ReadKey();
        }

        private static void ConsoleSetup()
        {
            Console.Title = "Food Trakker";
        }

    }
}
