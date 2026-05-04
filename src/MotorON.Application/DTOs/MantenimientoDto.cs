namespace MotorON.Application.DTOs;

public record MantenimientoCreateDto(
    Guid VehicleId,
    string Tipo,
    int Kilometraje,
    DateTime Fecha,
    decimal Costo,
    string? Descripcion
);

public record MantenimientoUpdateDto(
    string Tipo,
    int Kilometraje,
    DateTime Fecha,
    decimal Costo,
    string? Descripcion
);

public record MantenimientoResponseDto(
    Guid Id,
    Guid VehicleId,
    string Tipo,
    int Kilometraje,
    DateTime Fecha,
    decimal Costo,
    string? Descripcion,
    DateTime CreatedAtUtc,
    DateTime UpdatedAtUtc
);
