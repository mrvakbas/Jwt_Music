using Jwt_Music_Web.Dtos.SongDtos;

namespace Jwt_Music_Web.Services.SongServices
{
    public interface ISongServices
    {
        Task<List<ResultSongDto>> GetAllSongsAsync();
        Task<List<ResultSongDto>> GetAllSongsByDistinctCountryAsync();
        Task<List<ResultSongDto>> GetAllSongsByDistinctGenreAsync();
        Task<List<ResultSongDto>> GetFilteredSongsAsync(string sort, string country, string genre);
        Task<List<ResultSongDto>> GetPopularSongsAsync();
        Task<ResultSongDto> GetMostPopularRapAsync();

        Task<List<ResultSongDto>> GetRecommendedSongsAsync(int userId);
    }
}
