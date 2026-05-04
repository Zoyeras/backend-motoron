namespace MotorON.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IMantenimientoRepository Mantenimientos { get; }
    IGastoCombustibleRepository GastosCombustible { get; }
    IVehicleRepository Vehicles { get; }
    IUserRepository Users { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
