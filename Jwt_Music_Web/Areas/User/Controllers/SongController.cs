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
            int? userPackageId = HttpContext.Session.GetInt32("PackagId");

            var songs = await context.Songs
                .Include(s => s.Artist)
                .Include(s => s.Album)
                .Where(s => s.Level <= userPackageId)
                .OrderByDescending(x => x.ClickCount)
                .ToListAsync();

            return View(songs);
        }
    }
}
