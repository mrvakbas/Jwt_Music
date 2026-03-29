using Microsoft.AspNetCore.Mvc;

namespace Jwt_Music_Web.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
