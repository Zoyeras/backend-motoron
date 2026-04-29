namespace MotorON.Api.DTOs;

public record MantenimientoCreateDto(
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
