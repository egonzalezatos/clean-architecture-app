using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchProject.DTOs.DTOs;

namespace CleanArchProject.Services.Services
{
    public interface ISubplantService : IService
    {
        public Task<List<SubplantDto>> GetAll();
        public Task<SubplantDto?> GetOne(int id);
        public Task<SubplantDto> Register(SubplantDto plant);
        public Task<SubplantDto> Update(SubplantDto plant);
        public Task<int> Delete(int id);
    }
}