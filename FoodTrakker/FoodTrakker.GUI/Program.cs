using System.Collections.Generic;
using FoodTrakker.BusinessLogic.Models;


namespace FoodTrakker.GUI
{
    class Program
    {
        static void Main(string[] args)
        {
            WelcomeMessage.Run();
            LoadData.Load();
            LogInMenuGUI.LogIn();
            MainMenu.Create();
        }
    }
}
