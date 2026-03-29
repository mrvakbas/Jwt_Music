using Jwt_Music_Web.Dtos.AlbumDtos;
using Jwt_Music_Web.Dtos.SongDtos;

namespace Jwt_Music_Web.Dtos.ArtistDtos
{
    public class GetArtistByIdDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string ImageUrl { get; set; }
        public string BioInfo { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string InstagramUrl { get; set; }

        public List<ResultSongDto> Songs { get; set; }

        public List<ResultAlbumDto> Albums { get; set; }
    }
}
