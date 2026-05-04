using MediatR;
using MotorON.Application.DTOs;

namespace MotorON.Application.Features.GastosCombustible.Commands;

public record UpdateGastoCombustibleCommand(Guid Id, GastoCombustibleUpdateDto Dto) : IRequest<bool>;
