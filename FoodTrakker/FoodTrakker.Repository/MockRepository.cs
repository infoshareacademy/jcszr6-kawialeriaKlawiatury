using FoodTrakker.Core;
using FoodTrakker.Repository.Contracts;
using Newtonsoft.Json;

namespace FoodTrakker.Repository
{
    public abstract class MockRepository<T, IT> : IRepository<T, IT> where T : Iindexable<IT>
    {
        private static List<T> _dataList = new List<T>();

        public MockRepository(string path)
        {
            var dataString = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "DataJSON", path));
            _dataList = JsonConvert.DeserializeObject<List<T>>(dataString);
        }
        public Task<List<T>> GetAsync() => Task.FromResult(_dataList);
     

        public Task<T> GetAsync(IT id)
        {
            return Task.FromResult(_dataList.SingleOrDefault(t => id.Equals(t.Id)));
        }

        public void Add(T t)
        {
            _dataList.Add(t);
        }

        public void Delete(IT id)
        {
            var toDelete = _dataList.SingleOrDefault(t => id.Equals(t.Id));
            if (toDelete != null)
            {
                _dataList.Remove(toDelete);
            }
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(IT id)
        {
            throw new NotImplementedException();
        }
    }
}
