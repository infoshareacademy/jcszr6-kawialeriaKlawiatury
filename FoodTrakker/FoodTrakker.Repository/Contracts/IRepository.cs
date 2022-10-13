using FoodTrakker.Core.Model;

namespace FoodTrakker.Repository.Contracts
{
    public interface IRepository<T, IndexType>
    {
        public abstract Task<List<T>> GetAsync();
        public Task<T> GetAsync(IndexType id);
        public Task AddAsync(T entity);
        public Task DeleteAsync(IndexType id);
        public Task UpdateAsync(T entity);
        public Task<T> AddAsyncWithReturn(T entity);
    }
}
