using MediatR;

namespace SoulMedic.Api.Features.Specializations.Commands.CreateSpecialization
{
    public class CreateSpecializationCommand : IRequest<int>
    {
       
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
