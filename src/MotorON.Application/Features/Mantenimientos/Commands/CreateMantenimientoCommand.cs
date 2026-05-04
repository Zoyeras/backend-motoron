using MediatR;
using MotorON.Application.DTOs;

namespace MotorON.Application.Features.Mantenimientos.Commands;

public record CreateMantenimientoCommand(MantenimientoCreateDto Dto) : IRequest<MantenimientoResponseDto>;
