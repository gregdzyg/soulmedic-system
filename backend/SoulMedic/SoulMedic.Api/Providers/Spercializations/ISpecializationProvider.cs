using SoulMedic.Api.Domain.Entities;

namespace SoulMedic.Api.Providers.Spercializations
{
    public interface ISpecializationProvider
    {
        Task<List<Specialization>> GetAllAsync();
        Task<Specialization?> GetByIdAsync(int id);
    }
}
