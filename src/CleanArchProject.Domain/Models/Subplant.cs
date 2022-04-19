using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchProject.Domain.Models
{

    public class Subplant : Entity
    {
        [Required] public string Name { get; set; }

        [MaxLength(100)] public string? Description { get; set; }

        [Required] [ForeignKey("Plant_ID")] public Plant Plant { get; set; }

        [ForeignKey("ActualScene_ID")] public Scene? ActualScene { get; set; }

        public Subplant()
        {
        }
    }
}