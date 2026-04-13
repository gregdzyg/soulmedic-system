namespace SoulMedic.Api.Domain.Entities
{
    public class AppointmentRecommendation
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public string Content { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Appointment Appointment { get; set; } = null!;
    }
}