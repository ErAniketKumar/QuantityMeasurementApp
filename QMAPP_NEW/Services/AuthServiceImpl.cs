using BCrypt.Net;
using QMAPP_NEW.DTOs;
using QMAPP.Entities;
using QMAPP_NEW.Repositories;

using Google.Apis.Auth;
using Microsoft.AspNetCore.Mvc;

namespace QMAPP.Services;

public class AuthService
    : IAuthService
{
    private readonly IUserRepository _repo;

    private readonly JwtService _jwt;
    private readonly IConfiguration _configuration;

    public AuthService(
      IUserRepository repo,
      JwtService jwt,
      IConfiguration configuration)
    {
        _repo = repo;
        _jwt = jwt;
        _configuration = configuration;
    }

    public async Task<AuthResponseDto>
        Register(RegisterDto dto)
    {
        var existing =
            await _repo.GetByEmail(
                dto.Email);

        if (existing != null)
        {
            throw new Exception(
                "User already exists");
        }

        var user =
            new User
            {
                Name = dto.Name,
                Email = dto.Email,

                PasswordHash =
                    BCrypt.Net.BCrypt
                    .HashPassword(
                        dto.Password),

                Role = "USER"
            };

        await _repo.Add(user);

        var token =
            _jwt.GenerateToken(
                user.Email,
                user.Role);

        return new AuthResponseDto
        {
            Token = token,
            Email = user.Email,
            Role = user.Role
        };
    }

    public async Task<AuthResponseDto>
        Login(LoginDto dto)
    {
        var user =
            await _repo.GetByEmail(
                dto.Email);

        if (user == null)
            throw new Exception(
                "Invalid Credentials");

        bool valid =
            BCrypt.Net.BCrypt.Verify(
                dto.Password,
                user.PasswordHash);

        if (!valid)
            throw new Exception(
                "Invalid Credentials");

        var token =
            _jwt.GenerateToken(
                user.Email,
                user.Role);

        return new AuthResponseDto
        {
            Token = token,
            Email = user.Email,
            Role = user.Role
        };
    }

    public async Task<AuthResponseDto>
GoogleLogin(
    GoogleLoginDto dto)
    {
        var payload =
    await GoogleJsonWebSignature
        .ValidateAsync(
            dto.IdToken,
            new GoogleJsonWebSignature
                .ValidationSettings
            {
                Audience = new[]
                {
                    _configuration[
                        "Authentication:Google:ClientId"
                    ]
                }
            });

        var user =
            await _repo.GetByEmail(
                payload.Email);

        if (user == null)
        {
            user = new User
            {
                Name = payload.Name,
                Email = payload.Email,
                Role = "USER",

                PasswordHash = ""
            };

            await _repo.Add(user);
        }

        var token =
            _jwt.GenerateToken(
                user.Email,
                user.Role);

        return new AuthResponseDto
        {
            Token = token,
            Email = user.Email,
            Role = user.Role
        };
    }
}