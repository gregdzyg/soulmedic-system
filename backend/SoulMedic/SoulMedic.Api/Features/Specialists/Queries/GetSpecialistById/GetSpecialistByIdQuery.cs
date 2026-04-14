using MediatR;

namespace SoulMedic.Api.Features.Specialists.Queries.GetSpecialistById
{
    public class GetSpecialistByIdQuery : IRequest<SpecialistDetailsDto?>
    {
        public int Id { get; set; }

        public GetSpecialistByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class SpecialistDetailsDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Specialization { get; set; } = null!;
        public string Bio { get; set; } = null!;
    }
}