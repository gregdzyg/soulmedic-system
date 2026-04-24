using MediatR;
namespace SoulMedic.Api.Features.Specialists.Commands.CreateSpecialist
{
    public class CreateSpecialistCommand : IRequest<int>
    {
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public int SpecializationId { get; set; }
        public string Bio { get; set; } = null!;
        public string? ProfilePictureUrl { get; set; }
    }

   
}
