using MediatR;

namespace SoulMedic.Api.Features.Specialists.Commands.UpdateSpecialist
{
    public class UpdateSpecialistCommand : IRequest
    {
        public int Id { get; set; }

        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public int SpecializationId { get; set; }
        public string Bio { get; set; } = null!;
        public string? ProfilePictureUrl { get; set; }

    }
}
