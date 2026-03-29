using Jwt_Music.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Jwt_Music_Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController(AppDbContext _context) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var albums = await _context.Albums.Include(x => x.Artist).ThenInclude(y => y.Songs).ToListAsync();
            return Ok(albums);
        }
    }
}
