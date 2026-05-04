using MediatR;
using MotorON.Application.DTOs;
using MotorON.Domain.Interfaces;

namespace MotorON.Application.Features.Mantenimientos.Commands;

public class UpdateMantenimientoHandler : IRequestHandler<UpdateMantenimientoCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateMantenimientoHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(UpdateMantenimientoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.Mantenimientos.GetByIdAsync(request.Id, cancellationToken);
        if (entity is null) return false;

        var dto = request.Dto;
        entity.Tipo = dto.Tipo;
        entity.Kilometraje = dto.Kilometraje;
        entity.Fecha = dto.Fecha;
        entity.Costo = dto.Costo;
        entity.Descripcion = dto.Descripcion;
        entity.UpdatedAtUtc = DateTime.UtcNow;

        _unitOfWork.Mantenimientos.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
