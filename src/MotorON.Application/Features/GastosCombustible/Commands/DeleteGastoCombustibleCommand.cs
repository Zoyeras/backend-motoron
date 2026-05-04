using MediatR;

namespace MotorON.Application.Features.GastosCombustible.Commands;

public record DeleteGastoCombustibleCommand(Guid Id) : IRequest<bool>;
