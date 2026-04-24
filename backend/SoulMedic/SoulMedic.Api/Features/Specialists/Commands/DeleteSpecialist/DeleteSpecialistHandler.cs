using MediatR;
using Microsoft.EntityFrameworkCore;
using SoulMedic.Api.Data;

namespace SoulMedic.Api.Features.Specialists.Commands.DeleteSpecialist
{
    public class DeleteSpecialistHandler : IRequestHandler<DeleteSpecialistCommand>
    {
        private readonly ApplicationDbContext _context; 
        public DeleteSpecialistHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Handle(DeleteSpecialistCommand request, CancellationToken cancellationToken)
        {
            var specialist = await _context.Specialists.FirstOrDefaultAsync(s => s.Id == request.Id && s.IsActive, cancellationToken);
            if (specialist == null)
            {
                throw new KeyNotFoundException($"Specialist with id {request.Id} not found");
            }
            specialist.IsActive = false;
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
