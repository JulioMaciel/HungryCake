using System.IO;
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

            CreateMap<GridAddDto, Grid>();
            CreateMap<GridEditDto, Grid>();

            CreateMap<ColumnAddDto, Column>();
            CreateMap<ColumnEditDto, Column>();

            CreateMap<FeedRssAddDto, FeedRss>();
            CreateMap<FeedRssEditDto, FeedRss>();
                
        }
    }
}