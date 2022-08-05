using FoodTrakker.Core.Model;
using FoodTrakker.Repository.Contracts;
using FoodTrakker.Repository.Data;

namespace FoodTrakker.Repository
{
    public class ReviewRepository : Repository<Review, int>, IReviewRepository
    {
        public ReviewRepository(FoodTrakkerContext context) : base(context)
        {
        }
    }
}
