using Jwt_Music_Web.Services.ArtistServices;
using Microsoft.AspNetCore.Mvc;

namespace Jwt_Music_Web.Areas.User.Controllers
{
    [Area("User")]
    public class ArtistController(IArtistService artistService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var artist = await artistService.GetAllArtistsAsync();
            return View(artist);
        }
    }
}
