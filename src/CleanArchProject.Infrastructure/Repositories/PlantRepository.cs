using CleanArchProject.Domain.Models;
using CleanArchProject.Domain.Repositories;

namespace CleanArchProject.Infrastructure.Repositories
{

    public class PlantRepository : Repository<Plant, int>, IPlantRepository
    {
        public PlantRepository(EntityContext entityContext) : base(entityContext)
        {
        }

    }

}