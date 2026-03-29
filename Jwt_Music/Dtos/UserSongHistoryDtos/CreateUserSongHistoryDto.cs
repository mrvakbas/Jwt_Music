using Jwt_Music.Entities;

namespace Jwt_Music.Dtos.UserSongHistoryDtos
{
    public class CreateUserSongHistoryDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SongId { get; set; }
        public DateTime ListenedAt { get; set; } = DateTime.Now;
    }
}
