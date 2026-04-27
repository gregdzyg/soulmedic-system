using MediatR;

namespace SoulMedic.Api.Features.Specializations.Queries.GetSpecializationById
{
    public class GetSpecializationByIdQuery : IRequest<SpecializationDto?>
    {
        public int Id { get; set; }
        public GetSpecializationByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class SpecializationDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
