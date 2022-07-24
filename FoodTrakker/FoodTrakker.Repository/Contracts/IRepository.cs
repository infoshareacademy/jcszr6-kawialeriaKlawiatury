using FoodTrakker.Core.Model;

namespace FoodTrakker.Repository.Contracts
{
    public interface IRepository<T>
    {
        public abstract Task<List<T>> GetAsync();
        public Task<T> GetAsync(int id);
        public Task AddAsync(T entity);
        public Task DeleteAsync(int id);
        public Task UpdateAsync(T entity);
    }
}
