using MediatR;
using MotorON.Application.DTOs;

namespace MotorON.Application.Features.GastosCombustible.Queries;

public record GetGastoCombustibleByIdQuery(Guid Id) : IRequest<GastoCombustibleResponseDto?>;
