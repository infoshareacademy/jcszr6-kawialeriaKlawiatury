using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrakker.BusinessLogic.Repository;

namespace FoodTrakker.BusinessLogic.Models
{
    public class GetDataFromFile 
    {
        public static bool DeserializeData()
        {
            try
            {
                //Adding User & Review
                var userString = File.ReadAllText(Path.Combine(Environment.CurrentDirectory,"DataJSON","User.json"));
                var userJson = JsonConvert.DeserializeObject<List<User>>(userString);

                foreach (var user1 in userJson)
                {
                    DataRepository<User>.AddElement(user1);
                    for (int i = 0; i < user1.Reviews.Count; i++)
                    {
                        DataRepository<Review>.AddElement(user1.Reviews[i]);
                    }
                }

                //Adding Event & Food Truck
                var eventString = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "DataJSON", "Events.json"));
                var eventJson = JsonConvert.DeserializeObject<List<Event>>(eventString);

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
    }
}
