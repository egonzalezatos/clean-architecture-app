using System.ComponentModel.DataAnnotations;

namespace CleanArchProject.Domain.Models
{

    public class Plant : Entity
    {
        [MaxLength(100)] [Required] public string Name { get; set; }

        [MaxLength(100)] public string? Description { get; set; }

        [MaxLength(100)] public string? MapLink { get; set; }
        public double? MapLatitude { get; set; }
        public double? MapLongitude { get; set; }

        public Plant()
        {
        }

        public Plant(int id, string name, string? description, string? mapLink, double? mapLatitude,
            double? mapLongitude)
        {
            Id = id;
            Name = name;
            Description = description;
            MapLink = mapLink;
            MapLatitude = mapLatitude;
            MapLongitude = mapLongitude;
        }
    }
}