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

        public async Task<List<FoodTruckType>> GetRandomTypesAsync(int number)
        {
            var typesToShow = new List<FoodTruckType>();
            var types = await GetTypesAsync();
            var counter = 0;
            var randomNumberControll = new List<int>();
            Random random = new Random();
            if (types != null)
            {
                while (counter < number && counter < types.Count)
                {
                    int randomNumber = random.Next(0, types.Count);
                    if (randomNumberControll.Contains(randomNumber))
                    {
                        continue;
                    }
                    randomNumberControll.Add(randomNumber);
                    typesToShow.Add(types[randomNumber]);
                    counter++;
                }
            }
            return typesToShow;
        }



    }
}
