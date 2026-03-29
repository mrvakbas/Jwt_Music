using Jwt_Music.Entities;

namespace Jwt_Music.Services.TokenServices
{
    public interface ITokenService
    {
        Task<string> CreateTokenAsync(AppUser user);
    }
}
