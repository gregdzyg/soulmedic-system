using MediatR;

namespace SoulMedic.Api.Features.Specialists.Queries.GetSpecialists
{
    /// <summary>
    /// Zapytanie zwracające listę specjalistów.
    /// </summary>
    public class GetSpecialistsQuery : IRequest<List<SpecialistListItemDto>>
    {
    }

    /// <summary>
    /// DTO reprezentujące listę specjalistów (pozycja na liście).
    /// </summary>
    public class SpecialistListItemDto
    {
        /// <summary>Identyfikator specjalisty.</summary>
        public int Id { get; set; }

        /// <summary>Imię i nazwisko specjalisty (połączone).</summary>
        public string FullName { get; set; } = null!;

        /// <summary>Nazwa specjalizacji.</summary>
        public string Specialization { get; set; } = null!;

        /// <summary>Krótki opis/biografia specjalisty (opcjonalne).</summary>
        public string? ShortBio { get; set; }
    }
}