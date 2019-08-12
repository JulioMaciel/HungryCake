using System.Linq;
using AutoMapper;
using HungryCake.API.Dtos;
using HungryCake.API.Models;

namespace HungryCake.API.Helpers
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<UserUpdateDto, User>();
            CreateMap<UserRegisterDto, User>();

            CreateMap<FeedListDto, Feed>();
            CreateMap<FeedDetailDto, Feed>();
            CreateMap<FeedCreateDto, Feed>();
            CreateMap<FeedsSelectDto, Feed>();
        }
    }
}