using Microsoft.EntityFrameworkCore;
using SoulMedic.Api.Data;
using SoulMedic.Api.Domain.Entities;

namespace SoulMedic.Api.Providers.Spercializations
{
    public class SpecializationProvider : ISpecializationProvider
    {
        private readonly ApplicationDbContext _context;
        public SpecializationProvider(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Specialization>> GetAllAsync()
        {
            return await _context.Specializations
                .AsNoTracking()
                .Where(s => s.IsActive)
                .OrderBy(s => s.Name)
                .ToListAsync();
        }

        public async Task<Specialization?> GetByIdAsync(int id)
        {
           return await _context.Specializations.FirstOrDefaultAsync(s => s.Id == id && s.IsActive);
        }
    }
}
