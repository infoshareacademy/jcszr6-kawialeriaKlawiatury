﻿using AutoMapper;
using FoodTrakker.Repository;
using FoodTrakker.Core.Model;
using FoodTrakker.Repository.Contracts;
using Microsoft.AspNetCore.Http;
using System;

namespace FoodTrakker.Services
{
    public class FoodTruckService
    {
        private readonly IFoodTruckRepository _foodTruckRepository;
        private readonly IRepository<FoodTruckType, int> _foodTruckTypeRepository;
        private readonly IRepository<Review, int> _reviewRepository;
        private readonly IMapper _mapper;

        public FoodTruckService(IFoodTruckRepository foodTruckRepository, IRepository<FoodTruckType, int> foodTruckTypeRepository, IMapper mapper, IRepository<Review, int> reviewRepository)
        {
            _foodTruckRepository = foodTruckRepository;
            _foodTruckTypeRepository = foodTruckTypeRepository;
            _reviewRepository = reviewRepository;
            _mapper = mapper;

        }

        public Task<List<FoodTruck>> GetFoodTrucksAsync()
        {
            return _foodTruckRepository.GetAsync();
        }
        public Task<FoodTruck> GetFoodTruckAsync(int Id)
        {
            return _foodTruckRepository.GetAsync(Id);
        }

        public Task<List<FoodTruck>> GetFullFoodTruckInfoAsync()
        {
            return _foodTruckRepository.GetFullFoodTruckInfoAsync();
        }

        public Task<FoodTruck> GetFullFoodTruckInfoAsync(int Id)
        {
            return _foodTruckRepository.GetFullFoodTruckInfoAsync(Id);
        }

        public async Task<List<FoodTruck>> GetRandomFoodTrucks(int number)
        {
            var foodTrucksToShow = new List<FoodTruck>();
            var foodTrucks = await GetFoodTrucksAsync();
            var counter = 0;
            var randomNumberControll = new List<int>();
            Random random = new Random();
            if (foodTrucks != null)
            {
                while (counter < number && counter < foodTrucks.Count)
                {
                    int randomNumber = random.Next(0, foodTrucks.Count);
                    if (randomNumberControll.Contains(randomNumber))
                    {
                        continue;
                    }
                    randomNumberControll.Add(randomNumber);
                    foodTrucksToShow.Add(foodTrucks[randomNumber]);
                    counter++;
                }
            }
            return foodTrucksToShow;

        }

        public Task<List<FoodTruck>> GetOwnerFoodTrucks(string ownerId)
        {
            return _foodTruckRepository.GetOwnerFoodTrucks(ownerId);
        }

        public Task AddFoodTruck(FoodTruck foodTruck)
        {
            return _foodTruckRepository.AddAsync(foodTruck);
        }

        public Task UpdateFoodTruck(FoodTruck foodTruck)
        {
            return _foodTruckRepository.UpdateAsync(foodTruck);
        }

        public Task DeleteFoodTruck(int foodTruckId)
        {
            return _foodTruckRepository.DeleteAsync(foodTruckId);
        }
        public Task<List<FoodTruck>> FindFoodTruckAsync(string Name)
        {
            return _foodTruckRepository.FindFoodTruckAsync(Name);
        }

        public async Task<bool> IsNameUnique(string name)
        {
            var foodTrucks = await GetFoodTrucksAsync();
            foreach (var foodTruck in foodTrucks)
            {
                if (foodTruck.Name == name)
                    return false;
            }
            return true;
        }
        public Task<List<FoodTruck>> FindByCityAsync(string City)
        {
            return _foodTruckRepository.FindByCityAsync(City);
        }

        public Task<List<FoodTruck>> FindByStreetAsync(string City)
        {
            return _foodTruckRepository.FindByStreetAsync(City);
        }

        public Task<List<FoodTruck>> FindByTypeAsync(string Type)
        {
            return _foodTruckRepository.FindByTypeAsync(Type);
        }

        //public async Task<IEnumerable<string>> GetFoodTruckReviewRates()
        //{
        //    var rates = await _reviewRepository.GetAsync();
        //    return rates.Select(x => x.Rating.ToString());
        //}

        public async Task<IEnumerable<string>> GetFoodTruckTypeNames()
        {
            var types = await _foodTruckTypeRepository.GetAsync();
            return types.Select(x => x.Name);
        }
        //public Task<List<FoodTruck>> FindByEventAsync(string EventName)
        //{
        //    return _foodTruckRepository.FindByEventAsync(EventName);
        //}

        public string AddImageToFoodTruck(string name, IFormFile image)
        {
            if (image == null)
                return "food_truck.png";
            var imageType = image.ContentType;
            var type = imageType.Split("/");
            var fileName = Guid.NewGuid().ToString() + name + "." + type[1].ToString();
            var imagePath = CheckDirectory();
            var filePath = Path.Combine(imagePath, fileName);
            
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                image.CopyTo(fileStream);
            };
            
            return fileName;
        }


        public async Task<bool> DeleteImageFile(int id)
        {
            var foodTruckToDelete = await GetFullFoodTruckInfoAsync(id);
            if (foodTruckToDelete.ImageName == "food_truck.png")
            {
                 return false;
            }
            var fileName = foodTruckToDelete.ImageName;
            var imagePath = CheckDirectory();
            var filePath = Path.Combine(imagePath, fileName);
            File.Delete(filePath);
            return true;
        }

        public string CheckDirectory()
        {
            var imagePath = Path.Combine(Environment.CurrentDirectory, "wwwroot/img/FoodTruckImg");
            var directoryExists = Directory.Exists(imagePath);
            if (directoryExists == false)
            {
                Directory.CreateDirectory(imagePath);
            }
            return imagePath;
        }

    }
}
