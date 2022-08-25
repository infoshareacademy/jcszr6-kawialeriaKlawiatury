using AutoMapper;
using FoodTrakker.Core.Model;
using FoodTrakker.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrakker.Services.Profiles
{
    public class FoodTruckProfile : Profile
    {
        private readonly FoodTruckService _foodTruckServise;

        public FoodTruckProfile(FoodTruckService foodTruckService)
        {
            _foodTruckServise = foodTruckService;
        }

        public FoodTruckProfile()
        {
            CreateMap<FoodTruck, FoodTruckDto>()
                .ForMember(dto => dto.ImageFile, exp => exp.Ignore())
                .ReverseMap();
        }
    }
}
