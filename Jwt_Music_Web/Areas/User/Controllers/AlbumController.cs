using Jwt_Music_Web.Services.AlbumServices;
using Microsoft.AspNetCore.Mvc;

namespace Jwt_Music_Web.Areas.User.Controllers
{
    [Area("User")]
    public class AlbumController(IAlbumService albumService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var album = await albumService.GetAllAlbumAsync();
            return View(album);
        }
    }
}
