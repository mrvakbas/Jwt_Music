using Jwt_Music.Dtos.UserDtos;
using Jwt_Music.Entities;
using Jwt_Music.Services.TokenServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Jwt_Music.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;

        public LoginController(UserManager<AppUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            // Kullanıcıyı bul
            var user = await _userManager.FindByNameAsync(loginDto.Username);

            if (user is null)
            {
                return Unauthorized("Kullanıcı adı veya şifre hatalı!");
            }

            // Şifreyi kontrol et
            var passwordValid = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!passwordValid)
            {
                return Unauthorized("Kullanıcı adı veya şifre hatalı!");
            }

            // Token üret
            var token = await _tokenService.CreateTokenAsync(user);

            // Response döndür
            return Ok(new UserDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                ImageUrl = user.ImageUrl,
                PackageId = user.PackageId,
                Token = token,
            });
        }

    }
}
