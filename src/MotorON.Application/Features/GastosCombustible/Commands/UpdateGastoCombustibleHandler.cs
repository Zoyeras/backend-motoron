using MediatR;
using MotorON.Application.DTOs;
using MotorON.Domain.Interfaces;

namespace MotorON.Application.Features.GastosCombustible.Commands;

public class UpdateGastoCombustibleHandler : IRequestHandler<UpdateGastoCombustibleCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateGastoCombustibleHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(UpdateGastoCombustibleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.GastosCombustible.GetByIdAsync(request.Id, cancellationToken);
        if (entity is null) return false;

        var dto = request.Dto;
        entity.Fecha = dto.Fecha;
        entity.Litros = dto.Litros;
        entity.Costo = dto.Costo;
        entity.Kilometraje = dto.Kilometraje;
        entity.UpdatedAtUtc = DateTime.UtcNow;

        _unitOfWork.GastosCombustible.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
