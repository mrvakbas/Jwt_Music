using Jwt_Music_Web.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Jwt_Music_Web.Controllers
{
    [AuthCheckFilter]
    public class DiscoverController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
