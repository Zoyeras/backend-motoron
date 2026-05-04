namespace MotorON.Application.DTOs;

public record LoginDto(
    string Email,
    string Password
);

public record RegisterDto(
    string Email,
    string Password,
    string Name
);

public record AuthResponseDto(
    string Token,
    string RefreshToken,
    DateTime ExpiresAt
);
