using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotorON.Application.DTOs;
using MotorON.Application.Features.Vehicles.Commands;
using MotorON.Application.Features.Vehicles.Queries;

namespace MotorON.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class VehiclesController : ControllerBase
{
    private readonly IMediator _mediator;

    public VehiclesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllVehiclesQuery(), cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetVehicleByIdQuery(id), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] VehicleCreateDto dto, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new CreateVehicleCommand(dto), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] VehicleUpdateDto dto, CancellationToken cancellationToken)
    {
        var success = await _mediator.Send(new UpdateVehicleCommand(id, dto), cancellationToken);
        return success ? NoContent() : NotFound();
    }
}
