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
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<Review, ReviewDto>()
                .ForMember(dest => dest.FoodTruckName,
                opt => opt.MapFrom(src => src.FoodTruck.Name));
            CreateMap<ReviewDto, Review>();
        } 
    }
}
