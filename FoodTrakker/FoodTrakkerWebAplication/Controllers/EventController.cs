using FoodTrakker.BusinessLogic.Models;
using FoodTrakker.BusinessLogic.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FoodTrakkerWebAplication.Controllers
{
    public class EventController : Controller
    {
     
       private static List<Event> _eventList = DataRepository<Event>.GetData();
        //List<Event> _eventList = new List<Event>
        //{
        //    new Event
        //    {

        //        Name = "Super wydarzenie",
        //        Description = "Naprawde super wydarzenie",
        //        StartDate = DateTime.Now.AddDays(2),
        //        EndDate = DateTime.Now.AddDays(5),
        //        FoodTrucks = new List<FoodTruck> { new FoodTruck {Name = "Super FoodTruck",Description= "super",
        //        Type = new FoodTruckType{Name = "Mexican" } },new FoodTruck {Name = "Super FoodTruck3",Description= "super3",
        //        Type = new FoodTruckType{Name = "Pizza"} } }
        //    },
        //     new Event
        //    {

        //        Name = "Super wydarzeniE2",
        //        Description = "Naprawde super wydarzenie2",
        //        StartDate = DateTime.Now.AddDays(3),
        //        EndDate = DateTime.Now.AddDays(7),
        //        FoodTrucks = new List<FoodTruck> { new FoodTruck {Name = "Super FoodTruck2",Description= "super2",
        //        Type = new FoodTruckType{Name = "Mexican2" } } }
        //    },
        //      new Event
        //    {

        //        Name = "Super wydarzenie3",
        //        Description = "Naprawde super wydarzenie",
        //        StartDate = DateTime.Now.AddDays(2),
        //        EndDate = DateTime.Now.AddDays(5),
        //        FoodTrucks = new List<FoodTruck> { new FoodTruck {Name = "Super FoodTruck",Description= "super",
        //        Type = new FoodTruckType{Name = "Mexican" } },new FoodTruck {Name = "Super FoodTruck3",Description= "super3",
        //        Type = new FoodTruckType{Name = "Pizza"} } }
        //    },
        //       new Event
        //    {

        //        Name = "Super wydarzenie4",
        //        Description = "Naprawde super wydarzenie",
        //        StartDate = DateTime.Now.AddDays(25),
        //        EndDate = DateTime.Now.AddDays(30),
        //        FoodTrucks = new List<FoodTruck> { new FoodTruck {Name = "Super FoodTruck",Description= "super",
        //        Type = new FoodTruckType{Name = "Mexican" } },new FoodTruck {Name = "Super FoodTruck3",Description= "super3",
        //        Type = new FoodTruckType{Name = "Pizza"} } }
        //    },
        //        new Event
        //    {

        //        Name = "Super wydarzenie5",
        //        Description = "Naprawde super wydarzenie",
        //        StartDate = DateTime.Now.AddDays(1),
        //        EndDate = DateTime.Now.AddDays(5),
        //        FoodTrucks = new List<FoodTruck> { new FoodTruck {Name = "Super FoodTruck",Description= "super",
        //        Type = new FoodTruckType{Name = "Mexican" } },new FoodTruck {Name = "Super FoodTruck3",Description= "super3",
        //        Type = new FoodTruckType{Name = "Pizza"} } }
        //    },
        //};
        // GET: EventController
        public ActionResult Index()
        {
            GetDataFromFile.DeserializeData();
            var eventInNearFuture = _eventList.OrderBy(e => e.StartDate).Take(1).ToList();
            return View(eventInNearFuture);
        }

        
        

    }
}
