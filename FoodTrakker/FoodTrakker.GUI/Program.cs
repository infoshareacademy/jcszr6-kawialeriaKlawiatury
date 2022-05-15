using System;
using System.Collections.Generic;
using System.IO;
using FoodTrakker.BusinessLogic;
using FoodTrakker.BusinessLogic.Models;
using Newtonsoft.Json;

namespace FoodTrakker.GUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>();

            User user = new User()
            {
                FavouriteFoodTrucks = new List<FoodTruck>
                {
                    new FoodTruck()
                    {

                    }
                }
            };

            users.Add(user);
            var jsonText = JsonConvert.SerializeObject(user);

            var jsonLoaded = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "data.json"));
            var trucksList = JsonConvert.DeserializeObject<List<FoodTruck>>(jsonLoaded);

            Console.WriteLine("Hello World!");
        }
    }
}
