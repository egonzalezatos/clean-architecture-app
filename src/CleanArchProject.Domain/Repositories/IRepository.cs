using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchProject.Domain.Models;

namespace CleanArchProject.Domain.Repositories
{

    public interface IRepository<TEntity, TKey> where TEntity : Entity
    {
        Task<List<TEntity>> FindAll();
        Task<TEntity?> FindById(TKey id);
        void Insert(TEntity hero);
        void Delete(TKey id);
        void Update(TEntity hero);
        Task<int> Save();
    }

}