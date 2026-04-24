using MediatR;
using SoulMedic.Api.Data;
using SoulMedic.Api.Domain.Entities;

namespace SoulMedic.Api.Features.Specialists.Commands.CreateSpecialist
{
    public class CreateSpecialistHandler : IRequestHandler<CreateSpecialistCommand, int>
    {
        private readonly ApplicationDbContext _context;
        public CreateSpecialistHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateSpecialistCommand request, CancellationToken cancellationToken)
        {
            var specialist = new Specialist
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                SpecializationId = request.SpecializationId,
                Bio = request.Bio,
                ProfilePictureUrl = request.ProfilePictureUrl,
                IsActive = true
            };

            _context.Specialists.Add(specialist);
            await _context.SaveChangesAsync(cancellationToken);

            return specialist.Id;
        }
    }
}