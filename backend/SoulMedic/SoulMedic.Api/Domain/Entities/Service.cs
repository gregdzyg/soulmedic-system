namespace SoulMedic.Api.Domain.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;

        public ICollection<SpecialistService> SpecialistServices { get; set; } = new List<SpecialistService>();
    }
}
