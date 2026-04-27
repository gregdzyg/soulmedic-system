using MediatR;
using SoulMedic.Api.Data;

namespace SoulMedic.Api.Features.Specializations.Commands.DeleteSpecialization
{
    public class DeleteSpecializationHandler : IRequestHandler<DeleteSpecializationCommand>
    {
        private readonly ApplicationDbContext _context;
        public DeleteSpecializationHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Handle(DeleteSpecializationCommand request, CancellationToken cancellationToken)
        {
           var specialization = _context.Specializations.FirstOrDefault(s => s.Id == request.Id);
            if (specialization == null)
            {
                throw new Exception($"Specialization with id {request.Id} not found");
            }
            specialization.IsActive = false;
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
