using MediatR;
using SoulMedic.Api.Providers.Spercializations;

namespace SoulMedic.Api.Features.Specializations.Queries.GetSpecializationById
{
    public class GetSpecializationsByIdHandler : IRequestHandler<GetSpecializationByIdQuery, SpecializationDto?>
    {
        private readonly ISpecializationProvider _specializationProvider;
        public GetSpecializationsByIdHandler(ISpecializationProvider specializationProvider)
        {
            _specializationProvider = specializationProvider;
        }
        public async Task<SpecializationDto?> Handle(GetSpecializationByIdQuery request, CancellationToken cancellationToken)
        {
            var specialization = await _specializationProvider.GetByIdAsync(request.Id);
            if (specialization is null)
                return null;
            return new SpecializationDto
            {
                Id = specialization.Id,
                Name = specialization.Name,
                Description = specialization.Description
            };

        }
    }
    
}
