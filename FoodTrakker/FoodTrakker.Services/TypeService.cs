using FoodTrakker.Core.Model;
using FoodTrakker.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrakker.Services
{
    public class TypeService
    {
        private readonly ITypeRepository _typeRepository;
        public TypeService(ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        public Task<List<FoodTruckType>> GetTypesAsync()
        {
            return _typeRepository.GetAsync();
        }

        public Task<FoodTruckType> GetTypeAsync(int Id)
        {
            return _typeRepository.GetAsync(Id);
        }

    }
}
