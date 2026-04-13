using SoulMedic.Api.Domain.Enums;

namespace SoulMedic.Api.Domain.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int SpecialistId { get; set; }
        public int ServiceId { get; set; }
        public int? RoomId { get; set; }
        public int AvailabilitySlotId { get; set; }
        public AppointmentForm Form { get; set; }
        public AppointmentStatus Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Patient Patient { get; set; } = null!;
        public Specialist Specialist { get; set; } = null!;
        public Service Service { get; set; } = null!;
        public Room? Room { get; set; }
        public AvailabilitySlot AvailabilitySlot { get; set; } = null!;

        public AppointmentNote? AppointmentNote { get; set; }
        public AppointmentRecommendation? AppointmentRecommendation { get; set; }
    }
}