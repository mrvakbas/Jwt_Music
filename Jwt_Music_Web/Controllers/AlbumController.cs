using Jwt_Music_Web.Filters;
using Jwt_Music_Web.Services.AlbumServices;
using Microsoft.AspNetCore.Mvc;

namespace Jwt_Music_Web.Controllers
{
    [AuthCheckFilter]
    public class AlbumController(IAlbumService albumService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var allAlbum = await albumService.GetAllAlbumAsync();
            return View(allAlbum);
        }
    }
}
