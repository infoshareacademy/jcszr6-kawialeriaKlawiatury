using FoodTrakker.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodTrakkerWebAplication.ViewComponents
{
    public class FoodTruckReview : ViewComponent
    {
        private readonly ReviewService _reviewService;
        public FoodTruckReview(ReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int foodTruckId)
        {
            var reviews = await _reviewService.GetReviewsAsync();
            var reviewsToDisplay = reviews.Where(r => r.FoodTruckId == foodTruckId);

            return View(reviewsToDisplay);
        }

    }
}
