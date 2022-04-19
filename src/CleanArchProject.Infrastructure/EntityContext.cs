using CleanArchProject.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanArchProject.Infrastructure
{

    public class EntityContext : DbContext
    {
        public DbSet<Plant> Plants { get; set; }
        public DbSet<Subplant> Subplants { get; set; }
        public DbSet<Scene> Scenes { get; set; }

        public EntityContext(DbContextOptions<EntityContext> options) : base(options)
        {
        }

    }

}