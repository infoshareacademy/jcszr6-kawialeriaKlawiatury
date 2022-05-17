using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrakker.BusinessLogic.Repository
{
    public class DataRepository<T> where T : Iindexable
    {
        private static readonly List<T> _dataList = new List<T>();


        public static List<T> GetData()
        {
            return _dataList;
        }

        public static void AddElement(T element)
        {
            if (!DataRepository<T>.GetData().Any())
            {
                element.UpdateIndex(1);
                _dataList.Add(element);
            }
            else
            {
                var index = DataRepository<T>.GetData()
                    .OrderBy(t => t.Id)
                    .Last().Id;
                element.UpdateIndex(index+1);
                _dataList.Add(element);
            }
            
        }
    }
}
