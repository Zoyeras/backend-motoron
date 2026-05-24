namespace MotorON.Application.DTOs;

public record VehicleCreateDto(
    string Brand,
    string Model,
    int Year,
    int CurrentMileage,
    string? Placa,
    int? Cilindraje,
    string? Color,
    string? NumeroSerie
);

public record VehicleUpdateDto(
    string Brand,
    string Model,
    int Year,
    int CurrentMileage,
    string? Placa,
    int? Cilindraje,
    string? Color,
    string? NumeroSerie
);

public record VehicleResponseDto(
    Guid Id,
    string Brand,
    string Model,
    int Year,
    int CurrentMileage,
    string? Placa,
    int? Cilindraje,
    string? Color,
    string? NumeroSerie,
    DateTime CreatedAtUtc,
    DateTime UpdatedAtUtc
);
