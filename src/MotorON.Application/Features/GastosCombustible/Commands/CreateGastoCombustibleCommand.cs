using MediatR;
using MotorON.Application.DTOs;

namespace MotorON.Application.Features.GastosCombustible.Commands;

public record CreateGastoCombustibleCommand(GastoCombustibleCreateDto Dto) : IRequest<GastoCombustibleResponseDto>;
