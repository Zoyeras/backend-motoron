using MediatR;
using MotorON.Domain.Interfaces;

namespace MotorON.Application.Features.Vehicles.Commands;

public class UpdateVehicleHandler : IRequestHandler<UpdateVehicleCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVehicleHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.Vehicles.GetByIdAsync(request.Id, cancellationToken);
        if (entity is null) return false;

        var dto = request.Dto;
        entity.Brand = dto.Brand;
        entity.Model = dto.Model;
        entity.Year = dto.Year;
        entity.CurrentMileage = dto.CurrentMileage;
        entity.Placa = dto.Placa?.ToUpperInvariant().Trim();
        entity.Cilindraje = dto.Cilindraje;
        entity.Color = dto.Color;
        entity.NumeroSerie = dto.NumeroSerie;
        entity.UpdatedAtUtc = DateTime.UtcNow;

        _unitOfWork.Vehicles.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
