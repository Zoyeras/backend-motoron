using MediatR;
using MotorON.Application.DTOs;
using MotorON.Domain.Interfaces;

namespace MotorON.Application.Features.Mantenimientos.Queries;

public class GetMantenimientoByIdHandler : IRequestHandler<GetMantenimientoByIdQuery, MantenimientoResponseDto?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetMantenimientoByIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<MantenimientoResponseDto?> Handle(GetMantenimientoByIdQuery request, CancellationToken cancellationToken)
    {
        var m = await _unitOfWork.Mantenimientos.GetByIdAsync(request.Id, cancellationToken);
        if (m is null) return null;

        return new MantenimientoResponseDto(
            m.Id, m.VehicleId, m.Tipo, m.Kilometraje, m.Fecha,
            m.Costo, m.Descripcion, m.CreatedAtUtc, m.UpdatedAtUtc
        );
    }
}
