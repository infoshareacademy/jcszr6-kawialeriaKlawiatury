using FoodTrakker.Core.Model;
using FoodTrakker.Repository.Constants;
using FoodTrakker.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodTrakkerWebAplication.Controllers
{
    [Authorize(Roles = Roles.Administrator + "," + Roles.Owner)]
    public class LocationController : Controller
    {
        private readonly LocationService _locationService;
        public LocationController(LocationService locationService)
        {
            _locationService = locationService;
        }

        // GET: LocationController/Create
        public async Task<ActionResult> CreateLocation()
        {

            return View();
        }

        // POST: LocationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateLocation(Location location)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("CreateLocation");
            }

            try
            {

                await _locationService.AddLocation(location);

                return RedirectToAction("CreateFoodTruck", "Owner");
            }
            catch
            {
                return View();
            }
        }



    }
}
