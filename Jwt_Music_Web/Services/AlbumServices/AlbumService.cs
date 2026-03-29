using Jwt_Music_Web.Dtos.AlbumDtos;

namespace Jwt_Music_Web.Services.AlbumServices
{
    public class AlbumService(HttpClient httpClient) : IAlbumService
    {
        public async Task<List<ResultAlbumDto>> GetAllAlbumAsync()
        {
            var response = await httpClient.GetAsync("api/Albums");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<ResultAlbumDto>>();
            }

            return null;
        }
    
    }
}