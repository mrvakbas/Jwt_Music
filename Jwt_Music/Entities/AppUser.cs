using Microsoft.AspNetCore.Identity;

namespace Jwt_Music.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string FullName { get; set; }
        public string ImageUrl { get; set; }
        public int PackageId { get; set; }
        public Package Package { get; set; }

    }
}
