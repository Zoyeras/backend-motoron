using Microsoft.EntityFrameworkCore;
using MotorON.Api.Data;
using MotorON.Api.DTOs;

namespace MotorON.Api.Services;

public interface IOilChangeService
{
    Task<OilChangeForecastDto> CalculateForecastAsync(CancellationToken cancellationToken = default);
}

public class OilChangeService : IOilChangeService
{
    private const int DefaultOilChangeIntervalKilometers = 5000;
    private readonly AppDbContext _dbContext;

    public OilChangeService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<OilChangeForecastDto> CalculateForecastAsync(CancellationToken cancellationToken = default)
    {
        var lastOilChange = await _dbContext.Mantenimientos
            .AsNoTracking()
            .Where(m => m.Tipo.ToLower().Contains("aceite"))
            .OrderByDescending(m => m.Fecha)
            .FirstOrDefaultAsync(cancellationToken);

        var fuelRecords = await _dbContext.GastosCombustible
            .AsNoTracking()
            .OrderBy(g => g.Fecha)
            .ToListAsync(cancellationToken);

        var firstFuelRecord = fuelRecords.FirstOrDefault();
        var lastFuelRecord = fuelRecords.LastOrDefault();

        var averageDailyKilometers = 0;
        if (firstFuelRecord is not null && lastFuelRecord is not null)
        {
            var days = (lastFuelRecord.Fecha.Date - firstFuelRecord.Fecha.Date).TotalDays;
            var kilometersDelta = lastFuelRecord.Kilometraje - firstFuelRecord.Kilometraje;

            if (days > 0 && kilometersDelta > 0)
            {
                averageDailyKilometers = (int)Math.Round(kilometersDelta / days);
            }
        }

        var currentMileage = lastFuelRecord?.Kilometraje
            ?? lastOilChange?.Kilometraje
            ?? 0;

        var kilometersSinceLastOilChange = lastOilChange is null
            ? currentMileage
            : Math.Max(0, currentMileage - lastOilChange.Kilometraje);

        var kilometersRemaining = Math.Max(0, DefaultOilChangeIntervalKilometers - kilometersSinceLastOilChange);

        DateTime? estimatedDate = null;
        if (averageDailyKilometers > 0 && kilometersRemaining > 0)
        {
            estimatedDate = DateTime.UtcNow.Date.AddDays(Math.Ceiling((double)kilometersRemaining / averageDailyKilometers));
        }

        return new OilChangeForecastDto(
            averageDailyKilometers,
            kilometersSinceLastOilChange,
            kilometersRemaining,
            estimatedDate,
            lastOilChange?.Fecha,
            DefaultOilChangeIntervalKilometers
        );
    }
}
