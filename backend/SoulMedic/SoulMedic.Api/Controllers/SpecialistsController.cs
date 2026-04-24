using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoulMedic.Api.Features.Specialists.Commands.CreateSpecialist;
using SoulMedic.Api.Features.Specialists.Commands.DeleteSpecialist;
using SoulMedic.Api.Features.Specialists.Commands.UpdateSpecialist;
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

        [HttpPost]
        public async Task<IActionResult> CreateSpecialist([FromBody] CreateSpecialistCommand command)
        {
            var newId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetSpecialistById), new { id = newId }, newId);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateSpecialist(int id, [FromBody] UpdateSpecialistCommand command)
        {
            
            command.Id = id;
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteSpecialist(int id)
        {
            await _mediator.Send(new DeleteSpecialistCommand { Id = id });
            return NoContent();
        }
    }
}