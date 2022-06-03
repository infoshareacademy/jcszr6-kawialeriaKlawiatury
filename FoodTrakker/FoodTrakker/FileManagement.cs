using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FoodTrakker.BusinessLogic.Models;
using FoodTrakker.BusinessLogic.Repository;
using Newtonsoft.Json;

namespace FoodTrakker.BusinessLogic
{
    public class FileManagement
    {
        private static DirectoryInfo currentDirectory = new DirectoryInfo(Environment.CurrentDirectory);
        private static string pathUser = Path.Combine(currentDirectory.FullName, "DataJSON", "Saved", "savedUser.json");
        private static string pathEvents = Path.Combine(currentDirectory.FullName, "DataJSON", "Saved", "savedEvents.json");
        public static void SaveDataToFile()
        {
            checkIfFileExists(pathUser);
            string savedUserJson = JsonConvert.SerializeObject(DataRepository<User>.GetData());
            File.WriteAllText(pathUser, savedUserJson);

            //checkIfFileExists(pathEvents);
            string savedEventsJson = JsonConvert.SerializeObject(DataRepository<Event>.GetData());
            File.WriteAllText(pathEvents, savedEventsJson);
        }

        public static bool LoadSavedFiles()
        {
            try
            {
                //Adding User & Review
                var user = File.ReadAllText(pathUser);
                var userJson = JsonConvert.DeserializeObject<List<User>>(user);

                foreach (var user1 in userJson)
                {
                    DataRepository<User>.AddElement(user1);
                    for (int i = 0; i < user1.Reviews.Count; i++)
                    {
                        DataRepository<Review>.AddElement(user1.Reviews[i]);
                    }
                }

                //Adding Event & Food Truck
                var events = File.ReadAllText(pathEvents);
                var eventJson = JsonConvert.DeserializeObject<List<Event>>(events);

                foreach (var @event in eventJson)
                {
                    DataRepository<Event>.AddElement(@event);
                    for (int i = 0; i < @event.FoodTrucks.Count; i++)
                    {
                        DataRepository<FoodTruck>.AddElement(@event.FoodTrucks[i]);
                    }
                }
                return true;
            }
            catch (Exception)
            {
                Logger.Log();
                return false;
            }
        }

        public static void DeleteSavedData()
        {
            File.Delete(pathUser);
            File.Delete(pathEvents);
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
