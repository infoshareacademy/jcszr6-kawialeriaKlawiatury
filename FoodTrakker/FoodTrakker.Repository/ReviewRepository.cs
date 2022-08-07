using FoodTrakker.Core.Model;
using FoodTrakker.Repository.Contracts;
using FoodTrakker.Repository.Data;

namespace FoodTrakker.Repository
{
    public class ReviewRepository : Repository<Review, int>, IReviewRepository
    {
        private readonly FoodTrakkerContext _context;
        public ReviewRepository(FoodTrakkerContext context) : base(context)
        {
            _context = context;
        }
         public async  Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
        
       
    }
}
