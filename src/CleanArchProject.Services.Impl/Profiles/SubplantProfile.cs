using AutoMapper;
using CleanArchProject.Domain.Models;
using CleanArchProject.DTOs.DTOs;

namespace CleanArchProject.Services.Impl.Profiles
{
    public class SubplantProfile : Profile
    {
        public SubplantProfile()
        {
            CreateMap<Subplant, SubplantDto>().ReverseMap()
                .ForPath(entity => entity.Plant.Id, opts => opts.MapFrom(dto => dto.PlantId))
                .ForPath(entity => entity.ActualScene.Id, opts => opts.MapFrom(dto => dto.SceneId));
            CreateMap<Plant, SubplantPlantDto>();
            CreateMap<Scene, SubplantSceneDto>();
        }
    }
}