using MediatR;
using SoulMedic.Api.Providers.Spercializations;

namespace SoulMedic.Api.Features.Specializations.Queries.GetSpecializations
{
    public class GetSpecializationsHandler : IRequestHandler<GetSpecializationsQuery, List<SpecializationListItemDto>>
    {
        ISpecializationProvider _provider;

        public GetSpecializationsHandler(ISpecializationProvider provider)
        {
           _provider = provider;
        }

        public async Task<List<SpecializationListItemDto>> Handle(GetSpecializationsQuery request, CancellationToken cancellationToken)
        {
            var specializations = await _provider.GetAllAsync();
           
            var dtos = specializations.Select(s => new SpecializationListItemDto
            {
                Id = s.Id,
                Name = s.Name,
                ShortDescription = GetShortDescription(s.Description)
            }).ToList();

            return dtos;
        }

        private string? GetShortDescription(string? description)
        {
            if (string.IsNullOrEmpty(description))
                return null;

            return description.Length > 100
                ? description.Substring(0, 100) + "..."
                : description;
        }
    }
}
