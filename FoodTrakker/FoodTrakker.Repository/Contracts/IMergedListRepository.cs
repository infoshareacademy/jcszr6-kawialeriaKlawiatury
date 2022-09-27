using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrakker.Core.LinkingClasses;
using FoodTrakker.Core.Model;

namespace FoodTrakker.Repository.Contracts
{
    public interface IMergedListRepository : IRepository<MergedList,Task>
    {
       public Task<List<MergedList>> GetMergedListAsync(string FoodTruck, int Review, string Location, string User);
        Task<MergedList> GetAsync(string foodTruck, int review, string location, string user);
        Task SaveChanges();
        
    }
    
    
}
