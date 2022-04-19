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

    public class SubplantService : ISubplantService
    {
        private readonly ISubplantRepository _subplantRepository;
        private readonly IMapper _mapper;

        public SubplantService(ISubplantRepository subplantRepository, IMapper mapper)
        {
            _subplantRepository = subplantRepository;
            _mapper = mapper;
        }

        public async Task<List<SubplantDto>> GetAll()
        {
            List<SubplantDto> subplants = _mapper.Map<List<SubplantDto>>(
                await _subplantRepository.FindAll());
            return subplants;
        }

        public async Task<SubplantDto?> GetOne(int id)
        {
            Subplant? subplant = await _subplantRepository.FindById(id);
            if (subplant == null) return null;
            SubplantDto subplantDto = _mapper.Map<SubplantDto>(subplant);

            return subplantDto;
        }

        /**
     * Returns true if register completes.
     */
        public async Task<SubplantDto> Register(SubplantDto subplantDto)
        {
            Subplant subplant = _mapper.Map<Subplant>(subplantDto);
            _subplantRepository.Insert(subplant);
            if (await _subplantRepository.Save() > 0)
                return subplantDto;
            //else
            throw new Exception();
        }

        /**
     * returns true if updated completed
     */
        public async Task<SubplantDto> Update(SubplantDto subplantDto)
        {
            Subplant subplant = _mapper.Map<Subplant>(subplantDto);
            _subplantRepository.Update(subplant);
            if (await _subplantRepository.Save() > 0)
                return subplantDto;
            //else
            throw new Exception();
        }

        public async Task<int> Delete(int id)
        {
            _subplantRepository.Delete(id);
            await _subplantRepository.Save();
            return id;
        }

        // public async Task<List<SubplantDto>> FullQuery(Paginate? paginate, List<Sorting>? sorts = null, List<Filtering>? where = null, string? includes = null)
        // {
        //     return _mapper.ToDto<SubplantDto>(
        //         await _subplantRepository.FullQuery(paginate, sorts, where, includes));
        // }
    }
}