using MediatR;
using MotorON.Application.DTOs;

namespace MotorON.Application.Features.Vehicles.Commands;

public record CreateVehicleCommand(VehicleCreateDto Dto) : IRequest<VehicleResponseDto>;
