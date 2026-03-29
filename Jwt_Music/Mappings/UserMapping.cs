using AutoMapper;
using Jwt_Music.Dtos.UserDtos;
using Jwt_Music.Entities;

namespace Jwt_Music.Mappings
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<RegisterDto, AppUser>();
        }
    }
}