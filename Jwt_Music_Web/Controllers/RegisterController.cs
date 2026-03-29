using Jwt_Music_Web.Dtos.UserDtos;
using Jwt_Music_Web.Services.AccountServices;
using Microsoft.AspNetCore.Mvc;

namespace Jwt_Music_Web.Controllers
{
    public class RegisterController(IAccountService accountService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterDto registerDto)
        {
            var userResponse = await accountService.RegisterAsync(registerDto);

            if (userResponse != null)
            {
                return RedirectToAction("Index", "Login");
            }

            ModelState.AddModelError("", "Kayıt başarısız, bilgilerinizi kontrol ediniz!");
            return View();
        }
    }
}
