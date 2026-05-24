using MediatR;
using MotorON.Application.DTOs;

namespace MotorON.Application.Features.Vehicles.Queries;

public record GetVehicleByIdQuery(Guid Id) : IRequest<VehicleResponseDto?>;
