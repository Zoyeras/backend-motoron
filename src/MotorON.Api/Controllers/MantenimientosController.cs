using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotorON.Api.Data;
using MotorON.Api.DTOs;
using MotorON.Api.Models;
using MotorON.Api.Services;

namespace MotorON.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MantenimientosController : ControllerBase
{
    private readonly AppDbContext _dbContext;
    private readonly IOilChangeService _oilChangeService;

    public MantenimientosController(AppDbContext dbContext, IOilChangeService oilChangeService)
    {
        _dbContext = dbContext;
        _oilChangeService = oilChangeService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Mantenimiento>>> GetAll(CancellationToken cancellationToken)
    {
        var items = await _dbContext.Mantenimientos
            .AsNoTracking()
            .OrderByDescending(x => x.Fecha)
            .ToListAsync(cancellationToken);

        return Ok(items);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Mantenimiento>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var item = await _dbContext.Mantenimientos.FindAsync([id], cancellationToken);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<Mantenimiento>> Create([FromBody] MantenimientoCreateDto dto, CancellationToken cancellationToken)
    {
        var entity = new Mantenimiento
        {
            Tipo = dto.Tipo,
            Kilometraje = dto.Kilometraje,
            Fecha = dto.Fecha,
            Costo = dto.Costo,
            Descripcion = dto.Descripcion,
            CreatedAtUtc = DateTime.UtcNow,
            UpdatedAtUtc = DateTime.UtcNow
        };

        _dbContext.Mantenimientos.Add(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] MantenimientoUpdateDto dto, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Mantenimientos.FindAsync([id], cancellationToken);
        if (entity is null)
        {
            return NotFound();
        }

        entity.Tipo = dto.Tipo;
        entity.Kilometraje = dto.Kilometraje;
        entity.Fecha = dto.Fecha;
        entity.Costo = dto.Costo;
        entity.Descripcion = dto.Descripcion;
        entity.UpdatedAtUtc = DateTime.UtcNow;

        await _dbContext.SaveChangesAsync(cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Mantenimientos.FindAsync([id], cancellationToken);
        if (entity is null)
        {
            return NotFound();
        }

        _dbContext.Mantenimientos.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return NoContent();
    }

    [HttpGet("oil-change-forecast")]
    public async Task<ActionResult<OilChangeForecastDto>> GetOilChangeForecast(CancellationToken cancellationToken)
    {
        var forecast = await _oilChangeService.CalculateForecastAsync(cancellationToken);
        return Ok(forecast);
    }
}
