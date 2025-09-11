using Application.Interfaces;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Security;

public class JwtProvider : IJwtProvider
{
    private readonly IConfiguration _config;

    public JwtProvider(IConfiguration config)
    {
        _config = config;
    }

    public (string Token, DateTime ExpiresAt) GenerateToken(User user)
    {
        var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]!);

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
        };

        var expiresAt = DateTime.UtcNow.AddHours(1);

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: expiresAt,
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        return (tokenString, expiresAt);
    }
}
