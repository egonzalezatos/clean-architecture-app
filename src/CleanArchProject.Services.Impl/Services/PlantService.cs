using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchProject.Domain.Models;
using CleanArchProject.Domain.Repositories;
using CleanArchProject.DTOs.DTOs;
using CleanArchProject.Services.Services;

namespace CleanArchProject.Services.Impl.Services
{

    public class PlantService : IPlantService
    {
        private readonly IPlantRepository _plantRepository;
        private readonly IMapper _mapper;

        public PlantService(IPlantRepository plantRepository, IMapper mapper)
        {
            _plantRepository = plantRepository;
            _mapper = mapper;
        }

        public async Task<List<PlantDto>> GetAll()
        {
            return _mapper.Map<List<PlantDto>>(await _plantRepository.FindAll());
        }

        public async Task<PlantDto?> GetOne(int id)
        {
            Plant? plant = await _plantRepository.FindById(id);
            return _mapper.Map<Plant, PlantDto>(plant);
        }

        /**
     * Returns true if register completes.
     */
        public async Task<PlantDto> Register(PlantDto plantDtoWrite)
        {
            Plant plant = _mapper.Map<Plant>(plantDtoWrite); //_userMapper.Map<>(userDto)
            _plantRepository.Insert(plant);
            
            if (await _plantRepository.Save() > 0)
                return _mapper.Map<PlantDto>(plant);
            //else
            throw new Exception();
        }

        /**
     * returns true if updated completed
     */
        public async Task<PlantDto> Update(PlantDto plantDto)
        {
            Plant plant = _mapper.Map<PlantDto, Plant>(plantDto);
            _plantRepository.Update(plant);
            if (await _plantRepository.Save() > 0)
                return plantDto;
            //else
            throw new Exception();
        }

        public async Task<int> Delete(int id)
        {
            _plantRepository.Delete(id);
            await _plantRepository.Save();
            return id;
        }

        // public async Task<List<PlantDto>> FullQuery(Paginate? paginate, List<Sorting>? sorts = null, List<Filtering>? where = null, string? includes = null)
        // {
        //     return _mapper.ToDto<PlantDto>(
        //         await _plantRepository.FullQuery(paginate, sorts, where, includes));
        // }
    }
}