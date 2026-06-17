using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace QMAPP.Services;

public class JwtService
{
    private readonly IConfiguration _config;

    public JwtService(IConfiguration config)
    {
        _config = config;
    }

    public string GenerateToken(
        string email,
        string role)
    {
        var claims = new[]
        {
            new Claim(
                ClaimTypes.Email,
                email),

            new Claim(
                ClaimTypes.Role,
                role)
        };

        var key =
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    _config["Jwt:Key"]!));

        var credentials =
            new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

        var token =
            new JwtSecurityToken(
                claims: claims,
                expires:
                DateTime.Now.AddHours(2),
                signingCredentials:
                credentials);

        return new JwtSecurityTokenHandler()
            .WriteToken(token);
    }
}