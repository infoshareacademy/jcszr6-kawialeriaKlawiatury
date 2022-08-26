using AutoMapper;
using FoodTrakker.Services;
using FoodTrakker.Core.Model;
using FoodTrakker.Core.LinkingClasses;
using Microsoft.AspNetCore.Mvc;

namespace FoodTrakkerWebAplication.Controllers
{
    public class MergedListController : Controller
    {
        private readonly FoodTruckService _foodTruckService;
        private readonly UserService _userService;
        private readonly LocationService _locationService;
        
        private readonly IMapper _mapper;
        public MergedListController(FoodTruckService foodTruckService, UserService userService, LocationService locationService, IMapper mapper)
        {
            _foodTruckService=foodTruckService;
            _userService=userService;
            _locationService=locationService;
            
            _mapper=mapper;
        }
       
        public ActionResult Index()
        {
            

            return View();
        }














        // GET: MergedListController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MergedListController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MergedListController/Create
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

        // GET: MergedListController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MergedListController/Edit/5
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

        // GET: MergedListController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MergedListController/Delete/5
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
