using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotorON.Application.DTOs;
using MotorON.Application.Features.Mantenimientos.Commands;
using MotorON.Application.Features.Mantenimientos.Queries;
using MotorON.Application.Features.OilChange.Queries;

namespace MotorON.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class MantenimientosController : ControllerBase
{
    private readonly IMediator _mediator;

    public MantenimientosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllMantenimientosQuery(), cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetMantenimientoByIdQuery(id), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] MantenimientoCreateDto dto, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new CreateMantenimientoCommand(dto), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] MantenimientoUpdateDto dto, CancellationToken cancellationToken)
    {
        var success = await _mediator.Send(new UpdateMantenimientoCommand(id, dto), cancellationToken);
        return success ? NoContent() : NotFound();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var success = await _mediator.Send(new DeleteMantenimientoCommand(id), cancellationToken);
        return success ? NoContent() : NotFound();
    }

    [HttpGet("oil-change-forecast")]
    public async Task<IActionResult> GetOilChangeForecast(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetOilChangeForecastQuery(), cancellationToken);
        return Ok(result);
    }
}
