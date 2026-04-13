namespace SoulMedic.Api.Domain.Entities
{
    public class Specialist
    {
        public int Id { get; set; }
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public int SpecializationId { get; set; }
        public string Bio { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;

        public Specialization Specialization { get; set; } = null!;

        public ICollection<AvailabilitySlot> AvailabilitySlots { get; set; } = new List<AvailabilitySlot>();
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public ICollection<SpecialistService> SpecialistServices { get; set; } = new List<SpecialistService>();
    }
}