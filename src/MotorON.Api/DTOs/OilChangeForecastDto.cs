namespace MotorON.Api.DTOs;

public record OilChangeForecastDto(
    int AverageDailyKilometers,
    int KilometersSinceLastOilChange,
    int KilometersRemaining,
    DateTime? EstimatedDate,
    DateTime? LastOilChangeDate,
    int OilChangeIntervalKilometers
);
