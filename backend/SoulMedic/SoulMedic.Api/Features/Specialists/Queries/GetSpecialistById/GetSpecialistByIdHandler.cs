using MediatR;
using SoulMedic.Api.Providers.Specialists;

namespace SoulMedic.Api.Features.Specialists.Queries.GetSpecialistById
{
    public class GetSpecialistByIdHandler : IRequestHandler<GetSpecialistByIdQuery, SpecialistDetailsDto?>
    {
        private readonly ISpecialistProvider _specialistProvider;

        public GetSpecialistByIdHandler(ISpecialistProvider specialistProvider)
        {
            _specialistProvider = specialistProvider;
        }

        public async Task<SpecialistDetailsDto?> Handle(GetSpecialistByIdQuery request, CancellationToken cancellationToken)
        {
            var specialist = await _specialistProvider.GetByIdWithSpecializationAsync(request.Id);

            if (specialist is null)
                return null;

            return new SpecialistDetailsDto
            {
                Id = specialist.Id,
                FirstName = specialist.FirstName,
                LastName = specialist.LastName,
                Email = specialist.Email,
                PhoneNumber = specialist.PhoneNumber,
                Specialization = specialist.Specialization.Name,
                Bio = specialist.Bio
            };
        }
    }
}