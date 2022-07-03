using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrakker.BusinessLogic.Repository
{
    public interface IRepository<T>
    {
        public Task<List<T>> GetAsync();
        public Task<T> GetAsync(int id);
        
        public void Delete(int id);
        //DELETE itp itd...
    }
}
