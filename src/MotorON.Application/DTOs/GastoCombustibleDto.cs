namespace MotorON.Application.DTOs;

public record GastoCombustibleCreateDto(
    Guid VehicleId,
    DateTime Fecha,
    decimal Litros,
    decimal Costo,
    int? Kilometraje
);

public record GastoCombustibleUpdateDto(
    DateTime Fecha,
    decimal Litros,
    decimal Costo,
    int? Kilometraje
);

public record GastoCombustibleResponseDto(
    Guid Id,
    Guid VehicleId,
    DateTime Fecha,
    decimal Litros,
    decimal Costo,
    int? Kilometraje,
    decimal PrecioPorLitro,
    DateTime CreatedAtUtc,
    DateTime UpdatedAtUtc
);
