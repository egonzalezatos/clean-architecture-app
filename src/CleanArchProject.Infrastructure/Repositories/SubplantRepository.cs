using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchProject.Domain.Models;
using CleanArchProject.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CleanArchProject.Infrastructure.Repositories
{

    public class SubplantRepository : Repository<Subplant, int>, ISubplantRepository
    {
        public SubplantRepository(EntityContext entityContext) : base(entityContext)
        {
        }

        public override async Task<List<Subplant>> FindAll()
        {
            List<Subplant> subplants = await dbSet
                .Include(subplant => subplant.Plant)
                .ToListAsync();
            return subplants;
        }

        public override async Task<Subplant?> FindById(int id)
        {
            return await dbSet
                .Include(subplant => subplant.Plant)
                .Include(subplant => subplant.ActualScene)
                .Where(subplant => subplant.Id == id)
                .SingleOrDefaultAsync();
            //List<Subplant> subplants = await Query(subplant => subplant.Id == id, null, "Plant, ActualScene");
            //return subplants.Count == 0 ? null : subplants[0];
        }
    }
}