using AutoMapper;
using Car.Core.Entities;
using Car.Core.Models;

namespace Car.Infrastructure.Configurations
{
    public class MapperInitializer:Profile
    {
        public MapperInitializer()
        {
            CreateMap<CarDetails, CarDetailsDTO>().ReverseMap();
        }
    }
}
