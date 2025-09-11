using Application.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Security;

public class PasswordHasher : IPasswordHasher
{
    private readonly PasswordHasher<string> _hasher = new();

    public string HashPassword(string username, string password)
        => _hasher.HashPassword(username, password);

    public bool VerifyPassword(string username, string hash, string password)
    {
        var result = _hasher.VerifyHashedPassword(username, hash, password);
        return result != PasswordVerificationResult.Failed;
    }
}
