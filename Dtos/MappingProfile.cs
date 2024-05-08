using AutoMapper;
using perkmaker_backend.Models;

namespace perkmaker_backend.Dtos
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Entry, EntryDto>();
            CreateMap<User, UserDto>();
        }
    }
}
