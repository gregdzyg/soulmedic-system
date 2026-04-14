namespace SoulMedic.Api.Domain.Entities
{
    public class SpecialistService
    {
        public int Id { get; set; }
        public int SpecialistId { get; set; }
        public int ServiceId { get; set; }
        public int DurationInMinutes { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Specialist Specialist { get; set; } = null!;
        public Service Service { get; set; } = null!;

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}