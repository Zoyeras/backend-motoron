using MediatR;
using MotorON.Application.DTOs;
using MotorON.Domain.Entities;
using MotorON.Domain.Interfaces;

namespace MotorON.Application.Features.GastosCombustible.Commands;

public class CreateGastoCombustibleHandler : IRequestHandler<CreateGastoCombustibleCommand, GastoCombustibleResponseDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateGastoCombustibleHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GastoCombustibleResponseDto> Handle(CreateGastoCombustibleCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;
        var entity = new GastoCombustible
        {
            VehicleId = dto.VehicleId,
            Fecha = dto.Fecha,
            Litros = dto.Litros,
            Costo = dto.Costo,
            Kilometraje = dto.Kilometraje,
            CreatedAtUtc = DateTime.UtcNow,
            UpdatedAtUtc = DateTime.UtcNow
        };

        await _unitOfWork.GastosCombustible.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new GastoCombustibleResponseDto(
            entity.Id, entity.VehicleId, entity.Fecha, entity.Litros, entity.Costo,
            entity.Kilometraje, entity.PrecioPorLitro, entity.CreatedAtUtc, entity.UpdatedAtUtc
        );
    }
}
