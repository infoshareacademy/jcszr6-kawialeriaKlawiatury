using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrakker_WebBusinessLogic
{
    public interface IRepository<T>
    {
        public Task<List<T>> GetAsync();
        public Task<T> GetAsync(int id);

        public void Add(T t);
        public void Delete(int id);

        //DELETE itp itd...
    }
}
