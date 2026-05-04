using Microsoft.EntityFrameworkCore;
using MotorON.Domain.Entities;
using MotorON.Domain.Interfaces;
using MotorON.Infrastructure.Data;

namespace MotorON.Infrastructure.Repositories;

public class MantenimientoRepository : Repository<Mantenimiento>, IMantenimientoRepository
{
    public MantenimientoRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Mantenimiento>> GetAllOrderedByFechaDescAsync(CancellationToken cancellationToken = default)
    {
        return await DbSet
            .AsNoTracking()
            .OrderByDescending(x => x.Fecha)
            .ToListAsync(cancellationToken);
    }

    public async Task<Mantenimiento?> GetLastOilChangeAsync(CancellationToken cancellationToken = default)
    {
        return await DbSet
            .AsNoTracking()
            .Where(m => m.Tipo.ToLower().Contains("aceite"))
            .OrderByDescending(m => m.Fecha)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
