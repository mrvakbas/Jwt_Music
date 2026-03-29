using Jwt_Music_Web.Dtos.AlbumDtos;

namespace Jwt_Music_Web.Services.AlbumServices
{
    public interface IAlbumService
    {
        Task<List<ResultAlbumDto>> GetAllAlbumAsync();
    }
}
