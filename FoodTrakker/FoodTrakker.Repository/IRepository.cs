using FoodTrakker.Core.Model;

namespace FoodTrakker.Repository
{
    public interface IRepository<T>
    {
        public Task<List<T>> GetAsync();
        public Task<T> GetAsync(int id);

        public void Add(T t);
        public void Delete(int id);
    }
}
