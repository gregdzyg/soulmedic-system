using MediatR;
using Microsoft.EntityFrameworkCore;
using SoulMedic.Api.Data;

namespace SoulMedic.Api.Features.Specializations.Commands.UpdateSpecialization
{
    public class UpdateSpecializationHandler : IRequestHandler<UpdateSpecializationCommand>
    {
        private readonly ApplicationDbContext _context;
        public UpdateSpecializationHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Handle(UpdateSpecializationCommand request, CancellationToken cancellationToken)
        {
            var specialization = await _context.Specializations.FirstOrDefaultAsync(s => s.Id == request.Id && s.IsActive, cancellationToken);
            if (specialization == null)
            {
                throw new Exception($"Specialization with id {request.Id} not found");
            }
            specialization.Name = request.Name;
            specialization.Description = request.Description;
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
