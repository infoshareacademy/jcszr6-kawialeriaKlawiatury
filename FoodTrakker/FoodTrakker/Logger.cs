using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrakker.BusinessLogic
{
    public class Logger
    {
        internal static void Log()
        {      
            int hour = DateTime.Now.Hour;
            int minute = DateTime.Now.Minute;
            var loggerDirectory = Path.Combine("Log", "LogF", $"Logfile_at_{hour}_{minute}.txt");
            checkIfFileExists(loggerDirectory);
            using (var writer = File.CreateText(loggerDirectory))
            {
                writer.WriteLine("Files where not loaded\nPlease make sure you have User.json and Events.json files in your directory!");
            }


        }

        private static void checkIfFileExists(string filePath)
        {
            var dirName = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(dirName);
            }
        }
    }
}
