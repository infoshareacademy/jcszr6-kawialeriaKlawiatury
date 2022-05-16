using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrakker.BusinessLogic.Models
{
    public class GetDataFromFile
    {
        public static void DeserializeData()
        {
            //Adding User & Review
            var userString = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "User.json"));
            var userJson = JsonConvert.DeserializeObject<List<User>>(userString);

            foreach (var user1 in userJson)
            {
                UserRepository.AddUser(user1);
                for (int i = 0; i < user1.Reviews.Count; i++)
                {
                    if (ReviewRepository.GetAllReviews().Exists(r => r.Id == user1.Reviews[i].Id))
                    {
                        break;
                    }
                    ReviewRepository.AddReview(user1.Reviews[i]);
                }
            }

            //Adding Event & Food Truck
            var eventString = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "Events.json"));
            var eventJson = JsonConvert.DeserializeObject<List<Event>>(eventString);

            foreach (var @event in eventJson)
            {
                EventRepository.AddEvent(@event);
                for (int i = 0; i < @event.FoodTrucks.Count; i++)
                {
                    if (FoodTruckRepository.GetAllFoodTrucks().Exists(r => r.Id == @event.FoodTrucks[i].Id))
                    {
                        break;
                    }
                    FoodTruckRepository.AddFoodTruck(@event.FoodTrucks[i]);
                }
            }
        }
    }
}
