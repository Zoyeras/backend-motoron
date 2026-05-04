using MediatR;
using MotorON.Application.DTOs;

namespace MotorON.Application.Features.Auth.Commands;

public record LoginCommand(LoginDto Dto) : IRequest<AuthResponseDto>;
