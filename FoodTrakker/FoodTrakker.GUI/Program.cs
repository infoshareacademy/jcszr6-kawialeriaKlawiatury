using System.Collections.Generic;
using System;
using System.ComponentModel.Design.Serialization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
<<<<<<< HEAD
using FoodTrakker.BusinessLogic;
using FoodTrakker.BusinessLogic.Models;
using FoodTrakker.BusinessLogic.Repository;
using FoodTrakker.GUI.ConsoleInput;
=======
using FoodTrakker.BusinessLogic.Models;

>>>>>>> ada064cd7c8f842e58390f5383a599021878b59c

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
