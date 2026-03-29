using Jwt_Music.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Jwt_Music_Web.Areas.User.Controllers
{
    [Area("User")]
    public class SongController(AppDbContext context) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var songs = await context.Songs.OrderByDescending(x => x.ClickCount).ToListAsync();
            return View(songs);
        }
    }
}
