namespace MotorON.Api.DTOs;

public record GastoCombustibleCreateDto(
    DateTime Fecha,
    decimal Litros,
    decimal Costo,
    int Kilometraje
);

public record GastoCombustibleUpdateDto(
    DateTime Fecha,
    decimal Litros,
    decimal Costo,
    int Kilometraje
);
