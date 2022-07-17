using FoodTrakker.Core;
using FoodTrakker.Repository.Contracts;
using FoodTrakker.Repository.Data;
using Microsoft.EntityFrameworkCore;


namespace FoodTrakker.Repository
{
    public class Repository<T> : IRepository<T> where T : class, Iindexable
    {
        private readonly FoodTrakkerContext _context;
        public Repository(FoodTrakkerContext context)
        {
            _context = context;
        }
        public async Task AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var objectToDelete = GetAsync(id).Result;
            _context.Remove(objectToDelete);
            await _context.SaveChangesAsync(true);
        }

        public Task<List<T>> GetAsync()
        {
            return Task.FromResult(_context.Set<T>().ToList());
        }

        public Task<T> GetAsync(int id)
        {
            return Task.FromResult(_context.Set<T>().FirstOrDefault(t => t.Id == id));
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
