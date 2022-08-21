using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    }
}
