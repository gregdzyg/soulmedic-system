using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoulMedic.Api.Features.Specialists.Queries.GetSpecialistById;
using SoulMedic.Api.Features.Specialists.Queries.GetSpecialists;
using SoulMedic.Api.Providers.Specialists;

namespace SoulMedic.Api.Controllers
{
    /// <summary>
    /// API controller zarządzający zasobem specjalistów.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class SpecialistsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ISpecialistProvider _specialistProvider;

        /// <summary>
        /// Konstruktor kontrolera specjalistów.
        /// </summary>
        /// <param name="mediator">Mediator do wysyłania zapytań/komend.</param>
        /// <param name="specialistProvider">Provider do pobierania danych specjalistów.</param>
        public SpecialistsController(IMediator mediator, ISpecialistProvider specialistProvider)
        {
            _mediator = mediator;
            _specialistProvider = specialistProvider;
        }

        /// <summary>
        /// Zwraca listę aktywnych specjalistów z przypisaną specjalizacją.
        /// </summary>
        /// <returns>Lista specjalistów w postaci DTO.</returns>
        [HttpGet]
        public async Task<IActionResult> GetSpecialists()
        {
            var result = await _mediator.Send(new GetSpecialistsQuery());
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSpecialistById(int id)
        {
            var result = await _mediator.Send(new GetSpecialistByIdQuery(id));

            if (result is null)
                return NotFound();

            return Ok(result);
        }
    }
}