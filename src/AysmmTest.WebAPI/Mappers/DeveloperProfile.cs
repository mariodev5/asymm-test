using AutoMapper;
using AysmmTest.WebAPI.Dtos;
using AysmmTest.WebAPI.Entities;

namespace AysmmTest.WebAPI.Mappers
{
    public class DeveloperProfile : Profile
    {
        public DeveloperProfile()
        {
            CreateMap<Developer, DeveloperDto>().ReverseMap();
            CreateMap<Developer, DeveloperRequestDto>().ReverseMap();
        }
    }
}
