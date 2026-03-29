using Jwt_Music_Web.Dtos.ArtistDtos;
using Jwt_Music_Web.Filters;
using Jwt_Music_Web.Services.ArtistServices;
using Jwt_Music_Web.Services.SongServices;
using Microsoft.AspNetCore.Mvc;

namespace Jwt_Music_Web.Controllers
{
    [AuthCheckFilter]
    public class ArtistController(IArtistService artistService, ISongServices songService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var allArtistsByDistinctCountry = await artistService.GetAllArtistsByDistinctCountryAsync();
            ViewBag.allArtistsByDistinctCountry = allArtistsByDistinctCountry ?? new List<ResultArtistDto>();

            var allArtists = await artistService.GetAllArtistsAsync();
            ViewBag.allArtists = allArtists ?? new List<ResultArtistDto>();

            var totalArtistCount = await artistService.GetTotalArtistCountAsync();
            ViewBag.totalArtistCount = totalArtistCount;

            var mostPopularRap = await songService.GetMostPopularRapAsync();
            ViewBag.mostPopularRap = mostPopularRap.Title;
            ViewBag.mostPopularRapImageUrl = mostPopularRap.ImageUrl;

            var mostPopularSongs = await songService.GetPopularSongsAsync();
            ViewBag.mostPopularSongs = mostPopularSongs;

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("Index", allArtists);
            }

            return View(allArtists);
        }

        [HttpGet]
        public async Task<IActionResult> Filter(string Country)
        {
            var filteredArtists = await artistService.GetFilteredSongsAsync(Country ?? "all");

            return PartialView("ArtistListPartial", filteredArtists ?? new List<ResultArtistDto>());
        }

        [HttpGet]
        public async Task<IActionResult> ArtistDetail(int id)
        {
            var artist = await artistService.GetArtistByIdAsync(id);

            var artistTop5Tracks = await artistService.GetArtistTop5Tracks(id);
            ViewBag.artistTop5Tracks = artistTop5Tracks;

            var otherSongs = await artistService.GetArtistOtherTracks(id);
            ViewBag.otherSongs = otherSongs;

            //var mostPopularRap = await songService.GetMostPopularRapAsync();
            //ViewBag.mostPopularRap = mostPopularRap.Title;

            //var mostPopularSongs = await songService.GetPopularSongsAsync();
            //ViewBag.mostPopularSongs = mostPopularSongs;

            return View(artist);
        }

    }
}
