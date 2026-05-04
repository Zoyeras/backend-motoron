using MotorON.Domain.Entities;

namespace MotorON.Domain.Interfaces;

public interface IMantenimientoRepository : IRepository<Mantenimiento>
{
    Task<IEnumerable<Mantenimiento>> GetAllOrderedByFechaDescAsync(CancellationToken cancellationToken = default);
    Task<Mantenimiento?> GetLastOilChangeAsync(CancellationToken cancellationToken = default);
}
