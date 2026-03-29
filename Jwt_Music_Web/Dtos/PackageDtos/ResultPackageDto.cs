using Jwt_Music_Web.Dtos.UserDtos;

namespace Jwt_Music_Web.Dtos.PackageDtos
{
    public class ResultPackageDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<UserDto> Users { get; set; }
    }
}
