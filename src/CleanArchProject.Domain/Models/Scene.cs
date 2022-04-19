using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchProject.Domain.Models {

    public class Scene : Entity
    {
        public override int Id { get; set; }

        [Required] [MaxLength(100)] public string Name { get; set; }

        [MaxLength(100)] public string? Description { get; set; }


        [ForeignKey("Subplant_ID")] public Subplant? Subplant { get; set; }

        public Scene()
        {
        }
    }
}