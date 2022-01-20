using System.Collections.Generic;
using AutoMapper;
using CarAppDotNetApi.Dtos;
using CarAppDotNetApi.Models;

namespace CarAppDotNetApi.Mappers
{
    public class CarMapper : Profile
    {
        public CarMapper()
        {
            CreateMap<Car, CarDto>()
                .ForMember(dest =>
                        dest.ModelName,
                    opt => opt.MapFrom(src => src.Model.Name))
                .ReverseMap();
        }
    }
}