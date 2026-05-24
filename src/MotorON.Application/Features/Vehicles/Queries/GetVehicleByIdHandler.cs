using MediatR;
using MotorON.Application.DTOs;
using MotorON.Domain.Interfaces;

namespace MotorON.Application.Features.Vehicles.Queries;

public class GetVehicleByIdHandler : IRequestHandler<GetVehicleByIdQuery, VehicleResponseDto?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetVehicleByIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<VehicleResponseDto?> Handle(GetVehicleByIdQuery request, CancellationToken cancellationToken)
    {
        var vehicle = await _unitOfWork.Vehicles.GetByIdAsync(request.Id, cancellationToken);
        return vehicle?.ToResponseDto();
    }
}
