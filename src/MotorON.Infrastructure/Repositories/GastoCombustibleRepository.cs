using Microsoft.EntityFrameworkCore;
using MotorON.Domain.Entities;
using MotorON.Domain.Interfaces;
using MotorON.Infrastructure.Data;

namespace MotorON.Infrastructure.Repositories;

public class GastoCombustibleRepository : Repository<GastoCombustible>, IGastoCombustibleRepository
{
    public GastoCombustibleRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<GastoCombustible>> GetAllOrderedByFechaDescAsync(CancellationToken cancellationToken = default)
    {
        return await DbSet
            .AsNoTracking()
            .OrderByDescending(x => x.Fecha)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<GastoCombustible>> GetAllOrderedByFechaAscAsync(CancellationToken cancellationToken = default)
    {
        return await DbSet
            .AsNoTracking()
            .OrderBy(x => x.Fecha)
            .ToListAsync(cancellationToken);
    }
}
