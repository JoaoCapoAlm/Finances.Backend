using AutoMapper;
using Finances.Backend.Data.Dtos;
using Finances.Backend.Model;

namespace Finances.Backend.Profiles
{
    public class UserProfiler : Profile
    {
        public UserProfiler() {
            CreateMap<NewUserDto, User>();
        }
    }
}
