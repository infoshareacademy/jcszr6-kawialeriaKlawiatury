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
    class Program
    {
        public static List<Option> options;

        static void Main(string[] args)
        {
            GetDataFromFile.DeserializeData();
            LogInMenuGUI.LogIn();
            MainMenu.Create();

        }

    }
}
