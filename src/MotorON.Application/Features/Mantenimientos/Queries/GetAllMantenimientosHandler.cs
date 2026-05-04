using MediatR;
using MotorON.Application.DTOs;
using MotorON.Domain.Interfaces;

namespace MotorON.Application.Features.Mantenimientos.Queries;

public class GetAllMantenimientosHandler : IRequestHandler<GetAllMantenimientosQuery, IEnumerable<MantenimientoResponseDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllMantenimientosHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<MantenimientoResponseDto>> Handle(GetAllMantenimientosQuery request, CancellationToken cancellationToken)
    {
        var items = await _unitOfWork.Mantenimientos.GetAllOrderedByFechaDescAsync(cancellationToken);

        return items.Select(m => new MantenimientoResponseDto(
            m.Id, m.VehicleId, m.Tipo, m.Kilometraje, m.Fecha,
            m.Costo, m.Descripcion, m.CreatedAtUtc, m.UpdatedAtUtc
        ));
    }
}
