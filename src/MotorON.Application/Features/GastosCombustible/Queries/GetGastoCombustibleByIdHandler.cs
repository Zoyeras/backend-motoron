using MediatR;
using MotorON.Application.DTOs;
using MotorON.Domain.Interfaces;

namespace MotorON.Application.Features.GastosCombustible.Queries;

public class GetGastoCombustibleByIdHandler : IRequestHandler<GetGastoCombustibleByIdQuery, GastoCombustibleResponseDto?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetGastoCombustibleByIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GastoCombustibleResponseDto?> Handle(GetGastoCombustibleByIdQuery request, CancellationToken cancellationToken)
    {
        var g = await _unitOfWork.GastosCombustible.GetByIdAsync(request.Id, cancellationToken);
        if (g is null) return null;

        return new GastoCombustibleResponseDto(
            g.Id, g.VehicleId, g.Fecha, g.Litros, g.Costo,
            g.Kilometraje, g.PrecioPorLitro, g.CreatedAtUtc, g.UpdatedAtUtc
        );
    }
}
