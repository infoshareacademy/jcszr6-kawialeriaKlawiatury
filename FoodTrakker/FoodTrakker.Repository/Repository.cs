using FoodTrakker.Core;
using FoodTrakker.Core.Model;
using FoodTrakker.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrakker.Repository
{
    public class Repository<T> :  IRepository<T> where T : class, Iindexable
    {
        private readonly FoodTrakkerContext _context;
        public Repository(FoodTrakkerContext context)
        {
            _context = context;
        }
        public void Add(T t)
        {
            _context.Add(t);
            _context.SaveChanges();
           
        }

        public void Delete(int id)
        {
          var objectToDelete = GetAsync(id).Result;
            _context.Remove(objectToDelete);
            _context.SaveChanges(true);
        }

        public Task<List<T>> GetAsync()
        {
          return Task.FromResult(_context.Set<T>().ToList());
        }

        public Task<T> GetAsync(int id)
        {
            return Task.FromResult(_context.Set<T>().FirstOrDefault(t => t.Id == id));
        }
    }
}
