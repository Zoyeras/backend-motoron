using MediatR;
using MotorON.Application.DTOs;

namespace MotorON.Application.Features.Auth.Commands;

public record RegisterCommand(RegisterDto Dto) : IRequest<AuthResponseDto>;
