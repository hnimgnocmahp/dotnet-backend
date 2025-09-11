using Domain.Entities;

namespace Application.Interfaces;

public interface IJwtProvider
{
    (string Token, DateTime ExpiresAt) GenerateToken(User user);
}
