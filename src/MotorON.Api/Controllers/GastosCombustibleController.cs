using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotorON.Api.Data;
using MotorON.Api.DTOs;
using MotorON.Api.Models;

namespace MotorON.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GastosCombustibleController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public GastosCombustibleController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GastoCombustible>>> GetAll(CancellationToken cancellationToken)
    {
        var items = await _dbContext.GastosCombustible
            .AsNoTracking()
            .OrderByDescending(x => x.Fecha)
            .ToListAsync(cancellationToken);

        return Ok(items);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GastoCombustible>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var item = await _dbContext.GastosCombustible.FindAsync([id], cancellationToken);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<GastoCombustible>> Create([FromBody] GastoCombustibleCreateDto dto, CancellationToken cancellationToken)
    {
        var entity = new GastoCombustible
        {
            Fecha = dto.Fecha,
            Litros = dto.Litros,
            Costo = dto.Costo,
            Kilometraje = dto.Kilometraje,
            CreatedAtUtc = DateTime.UtcNow,
            UpdatedAtUtc = DateTime.UtcNow
        };

        _dbContext.GastosCombustible.Add(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] GastoCombustibleUpdateDto dto, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.GastosCombustible.FindAsync([id], cancellationToken);
        if (entity is null)
        {
            return NotFound();
        }

        entity.Fecha = dto.Fecha;
        entity.Litros = dto.Litros;
        entity.Costo = dto.Costo;
        entity.Kilometraje = dto.Kilometraje;
        entity.UpdatedAtUtc = DateTime.UtcNow;

        await _dbContext.SaveChangesAsync(cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.GastosCombustible.FindAsync([id], cancellationToken);
        if (entity is null)
        {
            return NotFound();
        }

        _dbContext.GastosCombustible.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return NoContent();
    }
}
