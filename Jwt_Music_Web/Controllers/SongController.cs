using Jwt_Music_Web.Filters;
using Jwt_Music_Web.Services.SongServices;
using Microsoft.AspNetCore.Mvc;

namespace Jwt_Music_Web.Controllers
{
    [AuthCheckFilter]
    public class SongController(ISongServices songService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var songs = await songService.GetAllSongsAsync();
            return View(songs);
        }
    }
}
