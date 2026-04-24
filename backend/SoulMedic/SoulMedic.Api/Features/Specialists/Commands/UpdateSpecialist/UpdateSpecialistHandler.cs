using MediatR;
using Microsoft.EntityFrameworkCore;
using SoulMedic.Api.Data;

namespace SoulMedic.Api.Features.Specialists.Commands.UpdateSpecialist
{
    public class UpdateSpecialistHandler : IRequestHandler<UpdateSpecialistCommand>
    {
        private readonly ApplicationDbContext _context;
        
        public UpdateSpecialistHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Handle(UpdateSpecialistCommand request, CancellationToken cancellationToken)
        {
            var specialist = await _context.Specialists.FirstOrDefaultAsync(s => s.Id == request.Id && s.IsActive, cancellationToken );
            if (specialist == null)
            {
                throw new KeyNotFoundException($"Specialist with id {request.Id} not found");
            }
            specialist.LastName = request.LastName;
            specialist.FirstName = request.FirstName;
            specialist.Email = request.Email;
            specialist.PhoneNumber = request.PhoneNumber;
            specialist.SpecializationId = request.SpecializationId;
            specialist.Bio = request.Bio;
            specialist.ProfilePictureUrl = request.ProfilePictureUrl;
            await _context.SaveChangesAsync(cancellationToken);
            
        }
    }
}
