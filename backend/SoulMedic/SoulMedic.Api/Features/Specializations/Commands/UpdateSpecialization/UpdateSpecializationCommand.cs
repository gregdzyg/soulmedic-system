using MediatR;

namespace SoulMedic.Api.Features.Specializations.Commands.UpdateSpecialization
{
    public class UpdateSpecializationCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
