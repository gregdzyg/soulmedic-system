namespace SoulMedic.Api.Domain.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Floor { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}