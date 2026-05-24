using MediatR;
using MotorON.Application.DTOs;

namespace MotorON.Application.Features.Vehicles.Commands;

public record UpdateVehicleCommand(Guid Id, VehicleUpdateDto Dto) : IRequest<bool>;
