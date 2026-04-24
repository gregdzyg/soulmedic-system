using MediatR;

namespace SoulMedic.Api.Features.Specialists.Commands.DeleteSpecialist
{
    public class DeleteSpecialistCommand : IRequest
    {
        public int Id { get; set; }
    }
}
