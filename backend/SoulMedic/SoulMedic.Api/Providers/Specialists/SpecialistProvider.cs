namespace SoulMedic.Api.Providers.Specialists
{
    using Microsoft.EntityFrameworkCore;
    using SoulMedic.Api.Data;
    using SoulMedic.Api.Domain.Entities;

    /// <summary>
    /// Domyślna implementacja <see cref="ISpecialistProvider"/> używająca EF Core.
    /// </summary>
    public class SpecialistProvider : ISpecialistProvider
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Konstruktor providera.
        /// </summary>
        public SpecialistProvider(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Zwraca aktywnych specjalistów z załadowaną nawigacją do specjalizacji.
        /// </summary>
        public async Task<List<Specialist>> GetAllWithSpecializationAsync()
        {
           return await _context.Specialists
                .AsNoTracking()
                .Include(s => s.Specialization)
                .Where(s => s.IsActive)
                .OrderBy(s => s.LastName)
                .ToListAsync();
        }

        /// <summary>
        /// Zwraca pojedynczego specjalistę wraz z nawigacją do specjalizacji lub null.
        /// </summary>
        public async Task<Specialist?> GetByIdWithSpecializationAsync(int id)
        {
            return await _context.Specialists
                .AsNoTracking()
                .Include(s => s.Specialization)
                .FirstOrDefaultAsync(s => s.Id == id && s.IsActive);
        }
    }
}
