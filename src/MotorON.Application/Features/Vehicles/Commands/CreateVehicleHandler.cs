using MediatR;
using MotorON.Application.DTOs;
using MotorON.Domain.Entities;
using MotorON.Domain.Interfaces;

namespace MotorON.Application.Features.Vehicles.Commands;

public class CreateVehicleHandler : IRequestHandler<CreateVehicleCommand, VehicleResponseDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateVehicleHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<VehicleResponseDto> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;
        var entity = new Vehicle
        {
            Brand = dto.Brand,
            Model = dto.Model,
            Year = dto.Year,
            CurrentMileage = dto.CurrentMileage,
            Placa = dto.Placa?.ToUpperInvariant().Trim(),
            Cilindraje = dto.Cilindraje,
            Color = dto.Color,
            NumeroSerie = dto.NumeroSerie,
            CreatedAtUtc = DateTime.UtcNow,
            UpdatedAtUtc = DateTime.UtcNow
        };

        await _unitOfWork.Vehicles.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.ToResponseDto();
    }
}
