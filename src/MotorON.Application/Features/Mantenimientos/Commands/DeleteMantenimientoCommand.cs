using MediatR;

namespace MotorON.Application.Features.Mantenimientos.Commands;

public record DeleteMantenimientoCommand(Guid Id) : IRequest<bool>;
