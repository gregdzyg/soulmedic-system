namespace SoulMedic.Api.Providers.Specialists
{
    using SoulMedic.Api.Domain.Entities;

    /// <summary>
    /// Abstrakcja dostępu do zbioru specjalistów (provider).
    /// </summary>
    public interface ISpecialistProvider
    {
        /// <summary>
        /// Zwraca listę aktywnych specjalistów wraz z załadowaną encją specjalizacji.
        /// </summary>
        /// <returns>Lista encji <see cref="Specialist"/>.</returns>
        Task<List<Specialist>> GetAllWithSpecializationAsync();

        /// <summary>
        /// Zwraca pojedynczego specjalistę (jeśli istnieje) wraz z nawigacją do specjalizacji.
        /// </summary>
        /// <param name="id">Id specjalisty.</param>
        /// <returns>Encja <see cref="Specialist"/> lub null jeżeli nie istnieje / nie jest aktywny.</returns>
        Task<Specialist?> GetByIdWithSpecializationAsync(int id);
    }
}
