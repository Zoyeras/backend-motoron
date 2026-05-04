using MotorON.Domain.Entities;
using MotorON.Domain.Interfaces;
using MotorON.Infrastructure.Data;

namespace MotorON.Infrastructure.Repositories;

public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
{
    public VehicleRepository(AppDbContext context) : base(context)
    {
    }
}
