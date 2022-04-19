using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchProject.DTOs.DTOs;

namespace CleanArchProject.Services.Services
{

    public interface IPlantService : IService
    {
        public Task<List<PlantDto>> GetAll();
        public Task<PlantDto?> GetOne(int id);
        public Task<PlantDto> Register(PlantDto plant);
        public Task<PlantDto> Update(PlantDto plant);
        
        public Task<int> Delete(int id);
    }

}