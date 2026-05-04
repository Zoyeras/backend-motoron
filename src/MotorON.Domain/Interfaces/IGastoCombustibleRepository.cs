using MotorON.Domain.Entities;

namespace MotorON.Domain.Interfaces;

public interface IGastoCombustibleRepository : IRepository<GastoCombustible>
{
    Task<IEnumerable<GastoCombustible>> GetAllOrderedByFechaDescAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<GastoCombustible>> GetAllOrderedByFechaAscAsync(CancellationToken cancellationToken = default);
}
