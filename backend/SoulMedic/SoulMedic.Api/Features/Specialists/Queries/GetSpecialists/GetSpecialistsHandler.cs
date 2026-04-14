using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using MediatR;
using SoulMedic.Api.Providers.Specialists;

namespace SoulMedic.Api.Features.Specialists.Queries.GetSpecialists
{
    /// <summary>
    /// Handler obsługujący <see cref="GetSpecialistsQuery"/>.
    /// </summary>
    public class GetSpecialistsHandler : IRequestHandler<GetSpecialistsQuery, List<SpecialistListItemDto>>
    {
        private readonly ISpecialistProvider _specialistProvider;

        /// <summary>
        /// Konstruktor handlera.
        /// </summary>
        /// <param name="specialistProvider">Provider dostępu do danych specjalistów.</param>
        public GetSpecialistsHandler(ISpecialistProvider specialistProvider)
        {
            _specialistProvider = specialistProvider;
        }

        /// <summary>
        /// Obsługuje zapytanie i mapuje encje na DTO.
        /// </summary>
        public async Task<List<SpecialistListItemDto>> Handle(GetSpecialistsQuery request, CancellationToken cancellationToken)
        {
            var specialists = await _specialistProvider.GetAllWithSpecializationAsync();

            var dtos = specialists.Select(specialist => new SpecialistListItemDto
            {
                Id = specialist.Id,
                FullName = $"{specialist.FirstName} {specialist.LastName}",
                Specialization = specialist.Specialization.Name,
                ShortBio = GetShortBio(specialist.Bio)
            }).ToList();

            return dtos;
        }

        /// <summary>
        /// Skraca bio do 100 znaków z dopisaniem "..." jeśli jest dłuższe.
        /// </summary>
        private string? GetShortBio(string? bio)
        {
            if (string.IsNullOrEmpty(bio))
                return null;

            return bio.Length > 100
                ? bio.Substring(0, 100) + "..."
                : bio;
        }
    }
}
