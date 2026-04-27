using MediatR;
using SoulMedic.Api.Data;
using SoulMedic.Api.Domain.Entities;

namespace SoulMedic.Api.Features.Specializations.Commands.CreateSpecialization
{
    public class CreateSpecializationHandler : IRequestHandler<CreateSpecializationCommand, int>
    {
        private readonly ApplicationDbContext _context;
        public CreateSpecializationHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateSpecializationCommand request, CancellationToken cancellationToken)
        {
            var specialization = new Specialization
            {
                Name = request.Name,
                Description = request.Description,
                IsActive = true
            };
            _context.Specializations.Add(specialization);
            await _context.SaveChangesAsync(cancellationToken);
            return specialization.Id;
        }
    }
}
