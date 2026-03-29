using Jwt_Music_Web.Services.SongServices;
using Microsoft.AspNetCore.Mvc;

namespace Jwt_Music_Web.ViewComponents
{
    public class _UiSuggestedSongsComponent(ISongServices songService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var userId = HttpContext.Session.GetInt32("UserId");
            //if (userId == null)
            //{
            //    return View(new List<ResultSongDto>());
            //}
            //var suggestedSongs = await songService.GetRecommendedSongsAsync(userId.Value);

            var suggestedSongs = await songService.GetAllSongsAsync();  
            return View(suggestedSongs);
        }
    }
}
