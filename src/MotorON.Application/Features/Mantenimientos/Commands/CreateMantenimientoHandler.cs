using MediatR;
using MotorON.Application.DTOs;
using MotorON.Domain.Entities;
using MotorON.Domain.Interfaces;

namespace MotorON.Application.Features.Mantenimientos.Commands;

public class CreateMantenimientoHandler : IRequestHandler<CreateMantenimientoCommand, MantenimientoResponseDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateMantenimientoHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<MantenimientoResponseDto> Handle(CreateMantenimientoCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;
        var entity = new Mantenimiento
        {
            VehicleId = dto.VehicleId,
            Tipo = dto.Tipo,
            Kilometraje = dto.Kilometraje,
            Fecha = dto.Fecha,
            Costo = dto.Costo,
            Descripcion = dto.Descripcion,
            CreatedAtUtc = DateTime.UtcNow,
            UpdatedAtUtc = DateTime.UtcNow
        };

        await _unitOfWork.Mantenimientos.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new MantenimientoResponseDto(
            entity.Id, entity.VehicleId, entity.Tipo, entity.Kilometraje, entity.Fecha,
            entity.Costo, entity.Descripcion, entity.CreatedAtUtc, entity.UpdatedAtUtc
        );
    }
}
