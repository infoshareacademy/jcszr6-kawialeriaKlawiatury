using FoodTrakker.Core.Model;
using FoodTrakker.Repository.Contracts;


namespace FoodTrakker.Services
{
    public class ReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<ICollection<Review>> GetReviewsAsync()
        {
            return await _reviewRepository.GetAsync();
        }
       
        public async Task<ICollection<Review>> GetFoodTruckReviewsAsync(int id)
        {
            return (await _reviewRepository.GetAsync()).Where(r => r.FoodTruckId == id).ToList();
        }
        public async Task AddReview(Review review)
        {
            await _reviewRepository.AddAsync(review);
        }
    }
}
