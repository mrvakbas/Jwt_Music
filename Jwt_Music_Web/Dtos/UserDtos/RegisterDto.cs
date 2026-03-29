namespace Jwt_Music_Web.Dtos.UserDtos
{
    public class RegisterDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ImageUrl { get; set; }
        public int PackageId { get; set; }
    }
}
