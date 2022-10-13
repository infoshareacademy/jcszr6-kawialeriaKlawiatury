using AutoMapper;
using FoodTrakker.Api.Models;
using FoodTrakker.Core.Model;

namespace FoodTrakker.Api.Profiles
{
    public class EventApiProfile : Profile
    {
        public EventApiProfile()
        {
            CreateMap<Event, EventApiPost>().ReverseMap();
            CreateMap<Event, EventApiGet>().ReverseMap();
        }
    }
}
