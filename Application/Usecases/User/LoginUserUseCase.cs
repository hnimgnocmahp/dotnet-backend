using Application.DTOs.User;
using Application.Interfaces;
using Domain.Interfaces;
using System.Security.Cryptography;

namespace Application.UseCases;

public class LoginUserUseCase
{
    private readonly IUserRepository _userRepo;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtProvider _jwtProvider;

    public LoginUserUseCase(IUserRepository userRepo, IPasswordHasher passwordHasher, IJwtProvider jwtProvider)
    {
        _userRepo = userRepo;
        _passwordHasher = passwordHasher;
        _jwtProvider = jwtProvider;
    }

    public async Task<LoginResponse?> ExecuteAsync(LoginRequest request)
    {
        var user = await _userRepo.GetByUsernameAsync(request.Username);
        if (user == null) return null;

        if (!_passwordHasher.VerifyPassword(user.Username, user.Password, request.Password))
            return null;

        var (accessToken, expiresAt) = _jwtProvider.GenerateToken(user);
        var expiresIn = (int)(expiresAt - DateTime.UtcNow).TotalSeconds;

        var randomNumber = new byte[32];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
        }
        var refreshToken = Convert.ToBase64String(randomNumber);

        var userDto = new UserResponse(user.Username);

        // var token = _jwtProvider.GenerateToken(user);
        return new LoginResponse(accessToken, expiresIn, refreshToken, userDto);
    }
}
