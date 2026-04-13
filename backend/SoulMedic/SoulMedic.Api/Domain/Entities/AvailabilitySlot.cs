namespace SoulMedic.Api.Domain.Entities
{
    public class AvailabilitySlot
    {
        public int Id { get; set; }
        public int SpecialistId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsAvailable { get; set; } = true;

        public Specialist Specialist { get; set; } = null!;
        public Appointment? Appointment { get; set; }
    }
}