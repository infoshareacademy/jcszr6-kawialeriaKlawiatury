using FoodTrakker.BusinessLogic.Models;
using FoodTrakker.BusinessLogic.Repository;
using FoodTrakker_WebBusinessLogic.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FoodTruck = FoodTrakker.BusinessLogic.Models.FoodTruck;

namespace FoodTrakkerWebAplication.Controllers
{
    public class ListController : Controller
    {
        private static List<FoodTruck> _trucks = DataRepository<FoodTruck>.GetData();
        // GET: ListController
        public ActionResult Index()
        {
            var trucks = (_trucks.FirstOrDefault());
            return View(_trucks);
        }

        // GET: ListController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ListController/Create
        public ActionResult Create(FoodTruck foodTruck)
        {
            if (!ModelState.IsValid)
            {
                return View(foodTruck);
            }

            try
            {
                _trucks.Add(foodTruck);
            }
            catch
            {
                return View();
            }

            return RedirectToAction("Index");


        }

        // POST: ListController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ListController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ListController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ListController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ListController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
