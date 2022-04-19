using System.ComponentModel.DataAnnotations;

namespace CleanArchProject.Domain.Models
{
    public abstract class Entity
    {
        public virtual int Id { get; set; }
    }

}