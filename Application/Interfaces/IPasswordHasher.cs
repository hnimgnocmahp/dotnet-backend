namespace Application.Interfaces;

public interface IPasswordHasher
{
    string HashPassword(string username, string password);
    bool VerifyPassword(string username, string hash, string password);
}
