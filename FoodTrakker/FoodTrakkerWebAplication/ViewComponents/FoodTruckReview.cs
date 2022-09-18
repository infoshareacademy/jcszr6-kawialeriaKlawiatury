using AutoMapper;
using FoodTrakker.Services;
using FoodTrakker.Services.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FoodTrakkerWebAplication.ViewComponents
{
    public class FoodTruckReview : ViewComponent
    {
        private readonly ReviewService _reviewService;
        private readonly IMapper _mapper;
        public FoodTruckReview(ReviewService reviewService,IMapper mapper)
        {
            _reviewService = reviewService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync(int foodTruckId)
        {
           
            var reviews = await _reviewService.GetReviewsAsync();
            var reviewsDto = _mapper.Map<ICollection<ReviewDto>>(reviews);
            var reviewsToDisplay = reviewsDto.Where(r => r.FoodTruckId.Equals( foodTruckId));

            return View(reviewsToDisplay);
        }

    }
}
