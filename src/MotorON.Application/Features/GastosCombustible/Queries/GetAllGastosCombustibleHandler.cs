using MediatR;
using MotorON.Application.DTOs;
using MotorON.Domain.Interfaces;

namespace MotorON.Application.Features.GastosCombustible.Queries;

public class GetAllGastosCombustibleHandler : IRequestHandler<GetAllGastosCombustibleQuery, IEnumerable<GastoCombustibleResponseDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllGastosCombustibleHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<GastoCombustibleResponseDto>> Handle(GetAllGastosCombustibleQuery request, CancellationToken cancellationToken)
    {
        var items = await _unitOfWork.GastosCombustible.GetAllOrderedByFechaDescAsync(cancellationToken);

        return items.Select(g => new GastoCombustibleResponseDto(
            g.Id, g.VehicleId, g.Fecha, g.Litros, g.Costo,
            g.Kilometraje, g.PrecioPorLitro, g.CreatedAtUtc, g.UpdatedAtUtc
        ));
    }
}
