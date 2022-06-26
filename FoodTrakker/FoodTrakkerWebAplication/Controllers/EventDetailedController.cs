using FoodTrakker.BusinessLogic.Models;
using FoodTrakker.BusinessLogic.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodTrakkerWebAplication.Controllers
{
    public class EventDetailedController : Controller
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
        //};

        // GET: EventController
        public ActionResult Index()
        {
            GetDataFromFile.DeserializeData();
            return View(_eventList);
        }

        // GET: EventController/Details/5
        public ActionResult Details(int id)
        {
            return View(_eventList.FirstOrDefault(e=>e.Id==id));
        }

        // GET: EventController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Event eventToCreate)
        {
            if (!ModelState.IsValid)
            {
                return View(eventToCreate);
            }
            try
            {
               _eventList.Add(eventToCreate);
            }
            catch
            {
                return View();
            }
            return RedirectToAction("Index");
        }

        // GET: EventController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_eventList.FirstOrDefault(e=>e.Id==id));
        }

        // POST: EventController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Event eventToEdit)
        {
            if (!ModelState.IsValid)
            {
                return View(_eventList);
            }
            try
            {
                var existingEvent = _eventList.FirstOrDefault(e=>e.Id==id);

                existingEvent.Name = eventToEdit.Name;
                existingEvent.Description = eventToEdit.Description;
                existingEvent.StartDate = eventToEdit.StartDate;
                existingEvent.EndDate = eventToEdit.EndDate;
                existingEvent.FoodTrucks = eventToEdit.FoodTrucks;
                existingEvent.Location = eventToEdit.Location;

                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
            
        }

        // GET: EventController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_eventList.FirstOrDefault(e=>e.Id == id));
        }

        // POST: EventController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Event @event)
        {
            try
            {
                var eventToDelete = _eventList.FirstOrDefault(e => e.Id == id);
                _eventList.Remove(eventToDelete);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
