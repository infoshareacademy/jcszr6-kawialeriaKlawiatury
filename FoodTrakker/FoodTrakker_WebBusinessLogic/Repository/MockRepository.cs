using Newtonsoft.Json;

namespace FoodTrakker_WebBusinessLogic.Repository
{
    public abstract class MockRepository<T> : IRepository<T> where T : Iindexable
    {
        private static List<T> _dataList = new List<T>();

        public MockRepository(string path)
        {
            var dataString = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "DataJSON", path));
            _dataList = JsonConvert.DeserializeObject<List<T>>(dataString);
        }
        public Task<List<T>> GetAsync() => Task.FromResult(_dataList);
     

        public Task<T> GetAsync(int id)
        {
            return Task.FromResult(_dataList.SingleOrDefault(t => t.Id == id));
        }

        public void Add(T t)
        {
            _dataList.Add(t);
        }

        public void Delete(int id)
        {
            var toDelete = _dataList.SingleOrDefault(t => t.Id == id);
            if (toDelete != null)
            {
                _dataList.Remove(toDelete);
            }
        }
    }
}
