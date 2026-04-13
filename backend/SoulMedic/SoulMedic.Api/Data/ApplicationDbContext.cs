using Microsoft.EntityFrameworkCore;
using SoulMedic.Api.Domain.Entities;

namespace SoulMedic.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<Specialist> Specialists => Set<Specialist>();
        public DbSet<Service> Services => Set<Service>();
        public DbSet<AvailabilitySlot> AvailabilitySlots => Set<AvailabilitySlot>();
        public DbSet<Appointment> Appointments => Set<Appointment>();
        public DbSet<Room> Rooms => Set<Room>();
        public DbSet<Specialization> Specializations => Set<Specialization>();
        public DbSet<AppointmentNote> AppointmentNotes => Set<AppointmentNote>();
        public DbSet<AppointmentRecommendation> AppointmentRecommendations => Set<AppointmentRecommendation>();
        public DbSet<SpecialistService> SpecialistServices => Set<SpecialistService>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // konfiguracja relacji
            modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Patient)
            .WithMany(p => p.Appointments)
            .HasForeignKey(a => a.PatientId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Specialist)
            .WithMany(s => s.Appointments)
            .HasForeignKey(a => a.SpecialistId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Service)
            .WithMany(s => s.Appointments)
            .HasForeignKey(a => a.ServiceId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AvailabilitySlot>()
            .HasOne(s => s.Specialist)
            .WithMany(s => s.AvailabilitySlots)
            .HasForeignKey(s => s.SpecialistId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
            .HasOne(a => a.AvailabilitySlot)
            .WithOne(s => s.Appointment)
            .HasForeignKey<Appointment>(a => a.AvailabilitySlotId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Room)
            .WithMany(r => r.Appointments)
            .HasForeignKey(a => a.RoomId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Specialist>()
            .HasOne(s => s.Specialization)
            .WithMany(s => s.Specialists)
            .HasForeignKey(s => s.SpecializationId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SpecialistService>()
            .HasOne(ss => ss.Specialist)
            .WithMany(specialist => specialist.SpecialistServices)
            .HasForeignKey(ss => ss.SpecialistId);

            modelBuilder.Entity<SpecialistService>()
             .HasOne(ss => ss.Service)
             .WithMany(service => service.SpecialistServices)
             .HasForeignKey(ss => ss.ServiceId);

            modelBuilder.Entity<AppointmentNote>()
            .HasOne(n => n.Appointment)
            .WithOne(a => a.AppointmentNote)
            .HasForeignKey<AppointmentNote>(n => n.AppointmentId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AppointmentRecommendation>()
            .HasOne(r => r.Appointment)
            .WithOne(a => a.AppointmentRecommendation)
            .HasForeignKey<AppointmentRecommendation>(r => r.AppointmentId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Service>()
            .Property(s => s.Price)
            .HasPrecision(10, 2);
        }
    }
}