using MediatR;

namespace SoulMedic.Api.Features.Specializations.Commands.DeleteSpecialization
{
    public class DeleteSpecializationCommand : IRequest
    {
        public int Id { get; set; }
    }
}
