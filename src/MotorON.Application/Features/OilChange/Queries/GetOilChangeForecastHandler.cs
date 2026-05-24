using MediatR;
using MotorON.Application.DTOs;
using MotorON.Domain.Interfaces;

namespace MotorON.Application.Features.OilChange.Queries;

public class GetOilChangeForecastHandler : IRequestHandler<GetOilChangeForecastQuery, OilChangeForecastDto>
{
    private const int DefaultOilChangeIntervalKilometers = 5000;
    private readonly IUnitOfWork _unitOfWork;

    public GetOilChangeForecastHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OilChangeForecastDto> Handle(GetOilChangeForecastQuery request, CancellationToken cancellationToken)
    {
        var lastOilChange = await _unitOfWork.Mantenimientos.GetLastOilChangeAsync(cancellationToken);

        var fuelRecords = (await _unitOfWork.GastosCombustible
            .GetAllOrderedByFechaAscAsync(cancellationToken)).ToList();

        var firstFuelRecord = fuelRecords.FirstOrDefault();
        var lastFuelRecord = fuelRecords.LastOrDefault();

        var averageDailyKilometers = 0;
        if (firstFuelRecord is not null && lastFuelRecord is not null
            && firstFuelRecord.Kilometraje.HasValue && lastFuelRecord.Kilometraje.HasValue)
        {
            var days = (lastFuelRecord.Fecha.Date - firstFuelRecord.Fecha.Date).TotalDays;
            var kilometersDelta = lastFuelRecord.Kilometraje.Value - firstFuelRecord.Kilometraje.Value;

            if (days > 0 && kilometersDelta > 0)
            {
                averageDailyKilometers = (int)Math.Round(kilometersDelta / days);
            }
        }

        var currentMileage = (lastFuelRecord?.Kilometraje)
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
