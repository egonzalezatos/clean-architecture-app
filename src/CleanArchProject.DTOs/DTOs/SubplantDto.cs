namespace CleanArchProject.DTOs.DTOs
{

    public class SubplantDto : Dto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public SubplantPlantDto Plant { get; set; }
        public SubplantSceneDto ActualScene { get; set; }
        public int PlantId { get; set; }
        public int SceneId { get; set; }
    }

    public class SubplantPlantDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class SubplantSceneDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
    
    
}