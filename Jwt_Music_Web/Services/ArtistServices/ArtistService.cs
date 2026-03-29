using Jwt_Music_Web.Dtos.ArtistDtos;
using Jwt_Music_Web.Dtos.SongDtos;
using Mapster;

namespace Jwt_Music_Web.Services.ArtistServices
{
    public class ArtistService(HttpClient httpClient) : IArtistService
    {
        public async Task<List<ResultArtistDto>> GetAllArtistsByDistinctCountryAsync()
        {
            var response = await httpClient.GetAsync("api/Artist/GetAllArtistsByDistinctCountry");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<ResultArtistDto>>();
            }

            return null; // Yetki hatası (401) veya başka bir hata varsa null döner
        }

        public async Task<List<ResultArtistDto>> GetAllArtistsAsync()
        {
            var response = await httpClient.GetAsync("api/Artist");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<ResultArtistDto>>();
            }

            return null; // Yetki hatası (401) veya başka bir hata varsa null döner
        }

        public async Task<List<ResultArtistDto>> GetFilteredSongsAsync(string Country)
        {
            var response = await httpClient.GetAsync($"api/Artist/GetFilteredArtists?Country={Country}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<ResultArtistDto>>();
            }

            return null; // Yetki hatası (401) veya başka bir hata varsa null döner
        }

        public async Task<int> GetTotalArtistCountAsync()
        {
            var response = await httpClient.GetAsync($"api/Artist/GetTotalArtistCount");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<int>();
            }

            return 0;
        }

        public async Task<GetArtistByIdDto> GetArtistByIdAsync(int id)
        {
            var response = await httpClient.GetAsync($"api/Artist/GetArtistById/{id}");

            if (response.IsSuccessStatusCode)
            {
                var value = await response.Content.ReadFromJsonAsync<ResultArtistDto>();
                var artist = value.Adapt<GetArtistByIdDto>();
                return artist;
            }

            return null;
        }

        public async Task<List<ResultSongDto>> GetArtistTop5Tracks(int id)
        {
            var response = await httpClient.GetAsync($"api/Artist/GetArtistTopTracks/{id}");

            if (response.IsSuccessStatusCode)
            {
                var artists = await response.Content.ReadFromJsonAsync<List<ResultSongDto>>();
                return artists;
            }

            return null;
        }

        public async Task<List<ResultSongDto>> GetArtistOtherTracks(int id)
        {
            var response = await httpClient.GetAsync($"api/Artist/GetOtherArtistSongs/{id}");

            if (response.IsSuccessStatusCode)
            {
                var artists = await response.Content.ReadFromJsonAsync<List<ResultSongDto>>();
                return artists;
            }

            return null;
        }
    }
}
