using Jwt_Music.Dtos.UserDtos;

namespace Jwt_Music.Dtos.PackageDtos
{
    public class ResultPackageDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UserDto> Users { get; set; }
    }
}
