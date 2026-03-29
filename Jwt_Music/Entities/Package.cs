namespace Jwt_Music.Entities
{
    public class Package
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<AppUser> Users { get; set; }
    }
}
