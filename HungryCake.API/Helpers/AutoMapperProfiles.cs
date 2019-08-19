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
            CreateMap<UserAddDto, User>();
            CreateMap<UserEditDto, User>();
            CreateMap<User, UserListDto>();
            CreateMap<User, UserDetailDto>();

            CreateMap<FeedAddDto, Feed>();
            CreateMap<FeedEditDto, Feed>();
            CreateMap<Feed, FeedListDto>();
            CreateMap<Feed, FeedDetailDto>();
            CreateMap<FeedsSelectDto, Feed>();
            
        }
    }
}