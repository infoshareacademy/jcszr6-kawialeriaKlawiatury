using FoodTrakker.BusinessLogic.Models;
using FoodTrakkerWebAplication.Contracts;

namespace FoodTrakkerWebAplication.Services
{
    public class DataFromFile : IGetable
    {
        public DataFromFile()
        {
            GetDataFromFile.DeserializeData();
        }
    }
}
