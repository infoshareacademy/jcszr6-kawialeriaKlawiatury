using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FoodTrakker.BusinessLogic;

namespace FoodTrakker.GUI
{
    public class FileManagementGUI
    {
        public static void Save()
        {
            FileManagement.SaveDataToFile();
            MainMenu.Create();
        }

        public static void Load()
        {
            FileManagement.LoadSavedFiles();
            MainMenu.Create();
        }

        public static void Delete()
        {
            FileManagement.DeleteSavedData();
            MainMenu.Create();
        }

    }
}
