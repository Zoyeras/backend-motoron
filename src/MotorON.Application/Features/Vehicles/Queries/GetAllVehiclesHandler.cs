using MediatR;
using MotorON.Application.DTOs;
using MotorON.Domain.Interfaces;

namespace MotorON.Application.Features.Vehicles.Queries;

public class GetAllVehiclesHandler : IRequestHandler<GetAllVehiclesQuery, IEnumerable<VehicleResponseDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllVehiclesHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<VehicleResponseDto>> Handle(GetAllVehiclesQuery request, CancellationToken cancellationToken)
    {
        var vehicles = await _unitOfWork.Vehicles.GetAllAsync(cancellationToken);
        return vehicles.Select(v => v.ToResponseDto());
    }
}
