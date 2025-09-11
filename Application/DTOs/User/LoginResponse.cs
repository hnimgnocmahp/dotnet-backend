namespace Application.DTOs.User;

public record LoginResponse(string Token, int expiresIn, string refreshToken, UserDto user);
