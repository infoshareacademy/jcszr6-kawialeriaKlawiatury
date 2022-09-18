using FoodTrakker.Core.Model;
using FoodTrakker.Repository.Contracts;
using FoodTrakker.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrakker.Repository
{
    public class TypeRepository : Repository<FoodTruckType,int>, ITypeRepository
    {
        public TypeRepository(FoodTrakkerContext context) : base(context)
        {
        }
    }
}
