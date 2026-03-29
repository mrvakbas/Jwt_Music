using AutoMapper;
using Jwt_Music.Dtos.UserDtos;
using Jwt_Music.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Jwt_Music.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController(UserManager<AppUser> userManager, IMapper mapper) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var user = mapper.Map<AppUser>(registerDto);

            var result = await userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "User");

                return Ok(new { Message = "Kayıt başarılı! Giriş yapabilirsiniz." });
            }

            return BadRequest(result.Errors);
        }
    }
}
