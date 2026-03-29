using Jwt_Music_Web.Dtos.UserDtos;
using Jwt_Music_Web.Services.AccountServices;
using Microsoft.AspNetCore.Mvc;

namespace Jwt_Music_Web.Controllers
{
    public class LoginController(IAccountService accountService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginDto loginDto)
        {
            var userResponse = await accountService.LoginAsync(loginDto);

            if (userResponse != null && !string.IsNullOrEmpty(userResponse.Token))
            {
                HttpContext.Session.SetString("JwtToken", userResponse.Token);

                HttpContext.Session.SetString("UserFullName", userResponse.FullName);

                HttpContext.Session.SetInt32("UserId", userResponse.Id);

                HttpContext.Session.SetString("UserImage", userResponse.ImageUrl);

                HttpContext.Session.SetInt32("PackagId", userResponse.PackageId);

                return Redirect("/User/Dashboard/Index");
            }

            ModelState.AddModelError("", "Giriş başarısız, bilgilerinizi kontrol ediniz!");
            return View();
        }

    }
}
