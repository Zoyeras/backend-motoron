using MediatR;
using MotorON.Application.DTOs;

namespace MotorON.Application.Features.Mantenimientos.Commands;

public record UpdateMantenimientoCommand(Guid Id, MantenimientoUpdateDto Dto) : IRequest<bool>;
