using AutoMapper;
using FoodTrakker.Core.Model;
using FoodTrakker.Repository.Constants;
using FoodTrakker.Repository.Data;
using FoodTrakker.Services;
using FoodTrakker.Services.DTOs;
using FoodTrakkerWebAplication.Models.ViewModel;
using FoodTrakkerWebAplication.ShowingAlerts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FoodTrakkerWebAplication.Controllers
{
    [Authorize(Roles = Roles.User)]
    public class UserController : Controller
    {
        private readonly EventService _eventService;
        private readonly FoodTruckService _foodTruckService;
        private readonly ReviewService _reviewService;
        private readonly FavouritesFoodTruckService _favouritesFoodTruckService;
        private readonly UserService _userService;
        private readonly IMapper _mapper;


        public UserController(EventService eventService, FoodTruckService foodTruckService,
            ReviewService reviewService,FavouritesFoodTruckService favouritesFoodTruckService,
            UserService userService,
            IMapper mapper)
        {
            _eventService = eventService;
            _foodTruckService = foodTruckService;
            _reviewService = reviewService;
            _favouritesFoodTruckService = favouritesFoodTruckService;
            _userService = userService;
            _mapper = mapper;

        }
        public async Task<ActionResult> Index()
        {

            var foodTrucks = await _foodTruckService.GetFullFoodTruckInfoAsync();
            var foodTruckDto = _mapper.Map<ICollection<FoodTruck>,
                ICollection<FoodTruckDto>>(foodTrucks);
          return View("../FoodTrucks/Index",foodTruckDto);
        }
        // GET: UserController/Create
        public ActionResult CreateReview(int id)
        {
            return View(new ReviewDto() { FoodTruckId = id});
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateReview(ReviewDto reviewDto)
        {
            User user = null;
            var x = User.Claims.FirstOrDefault(c => c.Type == @"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
            user = await _userService.GetUserAsync(x.Value);
            var review = _mapper.Map<Review>(reviewDto);
            review.Id = 0;
            review.User = user;
            if (!ModelState.IsValid)
            {
                return View(review);
            }

            try
            {
               await _reviewService.AddReview(review);
               ViewBag.Alert = AlertsService.ShowAlert(Alerts.Success, "Thank You for Your opinion!");
               return RedirectToAction("Details","FoodTrucks",new { id = reviewDto.FoodTruckId });
            }
            catch
            {
                return View();
            }
        }
        public async Task<ActionResult> AddFoodTruckToFavourites(int id)
        {
            FoodTruck foodTruck = null;
            FoodTruckDto foodTruckDto = null;
            try
            {
                var x = User.Claims.FirstOrDefault(c => c.Type == @"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");

               foodTruck= await _favouritesFoodTruckService.AddFoodTruckToFavourites(id, x.Value);
                
               foodTruckDto = _mapper.Map<FoodTruck,FoodTruckDto>(foodTruck);
               foodTruckDto.IsAddedToFav = await _foodTruckService.IsAddedToFav(id, x.Value);
               foodTruckDto.HasCurrentUserReview = await _foodTruckService.HasFoodTruckReviewFromUser(id, x.Value);
               ViewBag.Alert = AlertsService.ShowAlert(Alerts.Success, "You've got new favourite FoodTruck!");

            }catch(Exception ex)
            {
                ViewBag.Alert = AlertsService.ShowAlert(Alerts.Danger, "Something went wrong!");
                //add logs here
            }

            return View("../FoodTrucks/Details", foodTruckDto);
        }
        public async Task<ActionResult> RemoveFoodTruckFromFavourites(int id)
        {
            FoodTruck foodTruck = null;
            FoodTruckDto foodTruckDto = null;

            try
            {
                var x = User.Claims.FirstOrDefault(c => c.Type == @"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
                foodTruck = await _favouritesFoodTruckService.RemoveFoodTruckFromFavourites(id, x.Value);
                foodTruckDto = _mapper.Map<FoodTruck, FoodTruckDto>(foodTruck);
                foodTruckDto.IsAddedToFav = await _foodTruckService.IsAddedToFav(id, x.Value);
                foodTruckDto.HasCurrentUserReview = await _foodTruckService.HasFoodTruckReviewFromUser(id, x.Value);
                ViewBag.Alert = AlertsService.ShowAlert(Alerts.Success, "This is no longer your favourite FoodTruck!");

            }
            catch (Exception ex)
            {
                ViewBag.Alert = AlertsService.ShowAlert(Alerts.Danger, "Something went wrong!");
                //add logs here
            }

            return View("../FoodTrucks/Details", foodTruckDto);
        }
        public async Task<ActionResult> ListFavFoodTruck()
        {
            ICollection<FoodTruck> foodTrucks = null;
            ICollection<FoodTruckDto> foodTrucksDto = null;
            var x = User.Claims.FirstOrDefault(c => c.Type == @"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
            foodTrucks = await _favouritesFoodTruckService.FavFoodTrucks(x.Value);
            foodTrucksDto = _mapper.Map<ICollection<FoodTruck>,ICollection<FoodTruckDto>>(foodTrucks);
            if (foodTrucksDto!= null)
            {

                return View(foodTrucksDto);
            }

            return NotFound();
        }
        public async Task<ActionResult> ListReview()
        {
            List<Review> reviews = null;
            List<ReviewDto> reviewsDto = null;
            var x = User.Claims.FirstOrDefault(c => c.Type == @"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
            reviews = await _favouritesFoodTruckService.UserReviews(x.Value);
            reviewsDto = _mapper.Map<List<Review>, List<ReviewDto>>(reviews);

            if (reviewsDto!= null)
            {

                return View(reviewsDto);
            }

            return NotFound();
        }

    }
}
