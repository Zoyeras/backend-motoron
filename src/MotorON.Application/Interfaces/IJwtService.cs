using MotorON.Domain.Entities;

namespace MotorON.Application.Interfaces;

public interface IJwtService
{
    string GenerateToken(User user);
    string GenerateRefreshToken();
    DateTime GetTokenExpiration();
}
