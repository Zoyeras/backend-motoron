using MediatR;
using MotorON.Application.DTOs;
using MotorON.Application.Interfaces;
using MotorON.Domain.Interfaces;

namespace MotorON.Application.Features.Auth.Commands;

public class LoginHandler : IRequestHandler<LoginCommand, AuthResponseDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJwtService _jwtService;
    private readonly IPasswordHasher _passwordHasher;

    public LoginHandler(IUnitOfWork unitOfWork, IJwtService jwtService, IPasswordHasher passwordHasher)
    {
        _unitOfWork = unitOfWork;
        _jwtService = jwtService;
        _passwordHasher = passwordHasher;
    }

    public async Task<AuthResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users.GetByEmailAsync(request.Dto.Email, cancellationToken);
        if (user is null || !_passwordHasher.Verify(request.Dto.Password, user.PasswordHash))
            throw new UnauthorizedAccessException("Credenciales inválidas.");

        user.RefreshToken = _jwtService.GenerateRefreshToken();
        user.RefreshTokenExpiryUtc = DateTime.UtcNow.AddDays(7);
        user.UpdatedAtUtc = DateTime.UtcNow;

        _unitOfWork.Users.Update(user);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new AuthResponseDto(
            _jwtService.GenerateToken(user),
            user.RefreshToken,
            _jwtService.GetTokenExpiration()
        );
    }
}
