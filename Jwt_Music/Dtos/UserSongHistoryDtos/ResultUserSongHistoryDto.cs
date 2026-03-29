using Jwt_Music.Dtos.SongDtos;
using Jwt_Music.Dtos.UserDtos;

namespace Jwt_Music.Dtos.UserSongHistoryDtos
{
    public class ResultUserSongHistoryDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }
        public int SongId { get; set; }
        public ResultSongDto Song { get; set; }
        public DateTime ListenedAt { get; set; } = DateTime.Now;
    }
}
