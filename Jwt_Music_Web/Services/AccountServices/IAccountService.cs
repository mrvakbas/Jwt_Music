using Jwt_Music_Web.Dtos.UserDtos;

namespace Jwt_Music_Web.Services.AccountServices
{
    public interface IAccountService
    {
        Task<bool> RegisterAsync(RegisterDto registerDto);
        Task<UserDto> LoginAsync(LoginDto loginDto);
    }
}
