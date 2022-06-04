using System.Collections.Generic;
using FoodTrakker.BusinessLogic.Models;


namespace FoodTrakker.GUI
{
    class Program
    {
        public static List<Option> options;

        static void Main(string[] args)
        {
            //WelcomeMessage.Run();
            LoadData.Load();
            LogInMenuGUI.LogIn();
            MainMenu.Create();

        }

    }
}
