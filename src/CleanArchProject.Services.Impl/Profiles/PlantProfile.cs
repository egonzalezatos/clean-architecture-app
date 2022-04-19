using AutoMapper;
using CleanArchProject.Domain.Models;
using CleanArchProject.DTOs.DTOs;

namespace CleanArchProject.Services.Impl.Profiles
{
    public class PlantProfile : Profile
    {
        public PlantProfile()
        {
            CreateMap<Plant, PlantDto>().ReverseMap();
        }
    }
}