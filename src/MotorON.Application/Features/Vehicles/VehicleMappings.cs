using MotorON.Application.DTOs;
using MotorON.Domain.Entities;

namespace MotorON.Application.Features.Vehicles;

public static class VehicleMappings
{
    public static VehicleResponseDto ToResponseDto(this Vehicle v) => new(
        v.Id, v.Brand, v.Model, v.Year, v.CurrentMileage,
        v.Placa, v.Cilindraje, v.Color, v.NumeroSerie,
        v.CreatedAtUtc, v.UpdatedAtUtc
    );
}
