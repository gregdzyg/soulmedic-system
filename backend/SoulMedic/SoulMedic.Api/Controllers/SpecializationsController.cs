using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoulMedic.Api.Features.Specializations.Commands.CreateSpecialization;
using SoulMedic.Api.Features.Specializations.Commands.DeleteSpecialization;
using SoulMedic.Api.Features.Specializations.Commands.UpdateSpecialization;
using SoulMedic.Api.Features.Specializations.Queries.GetSpecializationById;
using SoulMedic.Api.Features.Specializations.Queries.GetSpecializations;

namespace SoulMedic.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpecializationsController : Controller
    {
        private readonly IMediator _mediator;

        public SpecializationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetSpecializations()
        {
            var result = await _mediator.Send(new GetSpecializationsQuery());
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSpecializationById(int id)
        {
            var result = await _mediator.Send(new GetSpecializationByIdQuery(id));
            if (result is null)
                return NotFound();
            return Ok(result);

        }

        [HttpPost]
        public async Task<IActionResult> CreateSpecialization([FromBody] CreateSpecializationCommand command)
        {
            var newId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetSpecializationById), new { id = newId }, newId);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateSpecialization(int id, [FromBody] UpdateSpecializationCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteSpecialization(int id)
        {
            await _mediator.Send(new DeleteSpecializationCommand { Id = id });
            return NoContent();
        }
    }

}