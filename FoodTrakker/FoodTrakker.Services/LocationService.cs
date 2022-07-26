using FoodTrakker.Core.Model;
using FoodTrakker.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrakker.Services
{
    public class LocationService
    {
        private readonly ILocationRepository _locationRepository;
        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public Task<List<Location>> GetLocationsAsync()
        {
            return _locationRepository.GetAsync();
        }

        public Task<Location> GetLocationAsync(int Id)
        {
            return _locationRepository.GetAsync(Id);
        }

    }
}
