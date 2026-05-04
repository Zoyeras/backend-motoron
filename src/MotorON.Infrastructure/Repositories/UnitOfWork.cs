using MotorON.Domain.Interfaces;
using MotorON.Infrastructure.Data;

namespace MotorON.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private IMantenimientoRepository? _mantenimientos;
    private IGastoCombustibleRepository? _gastosCombustible;
    private IVehicleRepository? _vehicles;
    private IUserRepository? _users;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public IMantenimientoRepository Mantenimientos =>
        _mantenimientos ??= new MantenimientoRepository(_context);

    public IGastoCombustibleRepository GastosCombustible =>
        _gastosCombustible ??= new GastoCombustibleRepository(_context);

    public IVehicleRepository Vehicles =>
        _vehicles ??= new VehicleRepository(_context);

    public IUserRepository Users =>
        _users ??= new UserRepository(_context);

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
