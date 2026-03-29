using Jwt_Music.Dtos.AlbumDtos;
using Jwt_Music.Dtos.SongDtos;

namespace Jwt_Music.Dtos.ArtistDtos
{
    public class ResultArtistDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string ImageUrl { get; set; }
        public string BioInfo { get; set; }
        public List<ResultSongDto> Songs { get; set; }
        public List<ResultAlbumDto> Albums { get; set; }
    }
}