using MediatR;
using Microsoft.AspNetCore.Mvc;
using MotorON.Application.DTOs;
using MotorON.Application.Features.GastosCombustible.Commands;
using MotorON.Application.Features.GastosCombustible.Queries;

namespace MotorON.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GastosCombustibleController : ControllerBase
{
    private readonly IMediator _mediator;

    public GastosCombustibleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllGastosCombustibleQuery(), cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetGastoCombustibleByIdQuery(id), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] GastoCombustibleCreateDto dto, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new CreateGastoCombustibleCommand(dto), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] GastoCombustibleUpdateDto dto, CancellationToken cancellationToken)
    {
        var success = await _mediator.Send(new UpdateGastoCombustibleCommand(id, dto), cancellationToken);
        return success ? NoContent() : NotFound();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var success = await _mediator.Send(new DeleteGastoCombustibleCommand(id), cancellationToken);
        return success ? NoContent() : NotFound();
    }
}
