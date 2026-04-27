using MediatR;

namespace SoulMedic.Api.Features.Specializations.Queries.GetSpecializations
{
    public class GetSpecializationsQuery : IRequest<List<SpecializationListItemDto>>
    {
    }

    public class SpecializationListItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? ShortDescription { get; set; } 
    }
}
