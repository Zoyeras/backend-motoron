using MediatR;
using MotorON.Application.DTOs;

namespace MotorON.Application.Features.Mantenimientos.Queries;

public record GetMantenimientoByIdQuery(Guid Id) : IRequest<MantenimientoResponseDto?>;
