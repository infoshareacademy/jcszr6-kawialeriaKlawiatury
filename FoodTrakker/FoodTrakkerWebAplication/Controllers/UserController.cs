using AutoMapper;
using FoodTrakker.Core.Model;
using FoodTrakker.Repository.Constants;
using FoodTrakker.Services;
using FoodTrakker.Services.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodTrakkerWebAplication.Controllers
{
    [Authorize(Roles = Roles.User)]
    public class UserController : Controller
    {
        private readonly EventService _eventService;
        private readonly FoodTruckService _foodTruckService;
        private readonly ReviewService _reviewService;
        private readonly FavouritesFoodTruckService _favouritesFoodTruckService;
        private readonly IMapper _mapper;

        public UserController(EventService eventService, FoodTruckService foodTruckService,
            ReviewService reviewService,FavouritesFoodTruckService favouritesFoodTruckService,
            IMapper mapper)
        {
            _eventService = eventService;
            _foodTruckService = foodTruckService;
            _reviewService = reviewService;
            _favouritesFoodTruckService = favouritesFoodTruckService;
            _mapper = mapper;
        }
        public async Task<ActionResult> Index()
        {
            var foodTrucks = await _foodTruckService.GetFoodTrucksAsync();
            var foodTrucksDto = _mapper.Map<List<FoodTruck>,List<FoodTruckDto>>(foodTrucks);
            var userReviews = new List<Review>() { };
            return View((foodTrucks: foodTrucksDto, reviews: userReviews));
        }
        // GET: UserController/Create
        public ActionResult CreateReview()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateReview(ReviewDto review)
        {
            var reviews = await _reviewService.GetReviewsAsync();
            var reviewsDto = _mapper.Map<ICollection<Review>,ICollection< ReviewDto>>(reviews);
           // var index = reviewsDto.OrderBy(r => r.Id).Last().Id;
           // review.Id = index + 1;
            
            if (!ModelState.IsValid)
            {
                return View(review);
            }

            try
            {

                reviewsDto.Add(review);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public async Task<ActionResult> AddFoodTruckToFavourites(int foodTruckId)
        {
            var x = User.Identity;
            
            


            return View();
        } 
    }
}
