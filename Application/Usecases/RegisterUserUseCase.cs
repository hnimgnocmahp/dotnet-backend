using Application.DTOs.User;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.UseCases;

public class RegisterUserUseCase
{
    private readonly IUserRepository _userRepo;
    private readonly IPasswordHasher _passwordHasher;

    public RegisterUserUseCase(IUserRepository userRepo, IPasswordHasher passwordHasher)
    {
        _userRepo = userRepo;
        _passwordHasher = passwordHasher;
    }

    public async Task<RegisterResponse?> ExecuteAsync(RegisterRequest request)
    {
        var existingUser = await _userRepo.GetByUsernameAsync(request.Username);
        if (existingUser != null)
        {
            throw new Exception("Username already exists");
        }

        var passwordHash = _passwordHasher.HashPassword(request.Username, request.Password);

        var user = new User
        {
            Username = request.Username,
            PasswordHash = passwordHash
        };

        var addUser = await _userRepo.AddAsync(user);

        return new RegisterResponse(addUser.Id, addUser.Username);
            
    
    }
}
