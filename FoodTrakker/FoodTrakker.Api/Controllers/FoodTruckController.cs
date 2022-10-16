using AutoMapper;
using FoodTrakker.Api.Models;
using FoodTrakker.Core.Model;
using FoodTrakker.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FoodTrakker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodTruckController : ControllerBase
    {
        private readonly FoodTruckService _foodTruckService;
        private readonly IMapper _mapper;

        public FoodTruckController(FoodTruckService foodTruckService, IMapper mapper)
        {
            _foodTruckService = foodTruckService;
            _mapper = mapper;
        }

        // GET: api/<FoodTruckController>
        [HttpGet]

        public IActionResult Get() => Ok(_foodTruckService.GetFoodTrucksAsync());

        // GET api/<FoodTruckController>/5
        [HttpGet("{id}")]
        public Task<FoodTruck?> GetFoodTruckById(int id)
        {
            var foodTruckById = _foodTruckService.GetFoodTruckAsync(id);

            if (foodTruckById is null)
            {
                throw new NullReferenceException();
            }
            return Task.FromResult<FoodTruck?>(foodTruckById.Result);
        }

        // POST api/<FoodTruckController>
        [HttpPost]
        public async Task<FoodTruckApiGet> CreateFoodTruck(FoodTruckApiPost foodTruckDto)
        {
            var @foodTruck = _mapper.Map<FoodTruck>(foodTruckDto);
            var foodTruckWithId = await _foodTruckService.AddFoodTruckAsyncWithReturn(@foodTruck);

            return _mapper.Map<FoodTruckApiGet>(foodTruckWithId);
        }

        // PUT api/<FoodTruckController>/5
        [HttpPut("{id}")]
        public Task<FoodTruck> UpdateFoodTruck(FoodTruck foodTruckUpdate)
        {
            var foodTrucks = _foodTruckService.GetFoodTrucksAsync();
            var foodTruckToUpdate = foodTrucks.Result.SingleOrDefault(f => f.Id == foodTruckUpdate.Id);
            var foodTruckToUpdateApi = _mapper.Map<FoodTruckApiGet>(foodTruckToUpdate);

            foodTruckToUpdateApi.Name = foodTruckUpdate.Name;
            foodTruckToUpdateApi.Description = foodTruckUpdate.Description;
            foodTruckToUpdateApi.LocationId = foodTruckUpdate.LocationId;
            foodTruckToUpdateApi.TypeId = foodTruckUpdate.TypeId;
            foodTruckToUpdateApi.OwnerId = foodTruckUpdate.OwnerId;

            if (foodTruckToUpdateApi is null)
            {
                throw new ArgumentNullException();
            }

            return Task.FromResult(foodTruckUpdate);

        }

        // DELETE api/<FoodTruckController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _foodTruckService.DeleteFoodTruck(id);
            return Ok();
        }
    }
}
