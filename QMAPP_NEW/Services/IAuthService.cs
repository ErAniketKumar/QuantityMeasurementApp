
using QMAPP_NEW.DTOs;

namespace QMAPP.Services
{
    public interface IAuthService
    {
        Task<AuthResponseDto> Register(
        RegisterDto dto);

        Task<AuthResponseDto> Login(
            LoginDto dto);

        Task<AuthResponseDto>
        GoogleLogin(
        GoogleLoginDto dto);
    }
}