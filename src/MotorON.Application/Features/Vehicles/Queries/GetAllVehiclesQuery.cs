using MediatR;
using MotorON.Application.DTOs;

namespace MotorON.Application.Features.Vehicles.Queries;

public record GetAllVehiclesQuery : IRequest<IEnumerable<VehicleResponseDto>>;
