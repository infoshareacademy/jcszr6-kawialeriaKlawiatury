using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FoodTrakker.BusinessLogic.Models;

namespace FoodTrakker.GUI
{
    public class LoadData
    {
        public static void Load()
        {
            var uploadFiles = GetDataFromFile.DeserializeData();
            if (!uploadFiles)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Data not loaded!\nCheck log file");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(2000);
            }
        }
    }
}
