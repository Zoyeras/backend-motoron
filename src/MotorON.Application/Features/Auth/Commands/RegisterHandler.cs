using MediatR;
using MotorON.Application.DTOs;
using MotorON.Application.Interfaces;
using MotorON.Domain.Entities;
using MotorON.Domain.Interfaces;

namespace MotorON.Application.Features.Auth.Commands;

public class RegisterHandler : IRequestHandler<RegisterCommand, AuthResponseDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJwtService _jwtService;
    private readonly IPasswordHasher _passwordHasher;

    public RegisterHandler(IUnitOfWork unitOfWork, IJwtService jwtService, IPasswordHasher passwordHasher)
    {
        _unitOfWork = unitOfWork;
        _jwtService = jwtService;
        _passwordHasher = passwordHasher;
    }

    public async Task<AuthResponseDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var existing = await _unitOfWork.Users.GetByEmailAsync(request.Dto.Email, cancellationToken);
        if (existing is not null)
            throw new InvalidOperationException("El email ya está registrado.");

        var user = new User
        {
            Email = request.Dto.Email,
            PasswordHash = _passwordHasher.Hash(request.Dto.Password),
            Name = request.Dto.Name,
            RefreshToken = _jwtService.GenerateRefreshToken(),
            RefreshTokenExpiryUtc = DateTime.UtcNow.AddDays(7),
            CreatedAtUtc = DateTime.UtcNow,
            UpdatedAtUtc = DateTime.UtcNow
        };

        await _unitOfWork.Users.AddAsync(user, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new AuthResponseDto(
            _jwtService.GenerateToken(user),
            user.RefreshToken,
            _jwtService.GetTokenExpiration()
        );
    }
}
