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

            CreateMap<FeedRssAddDto, FeedRss>();
                // .ForMember(dest => dest.Icon, opt => {
                //     opt.MapFrom(src => File.ReadAllBytes(src.NewIconPath));
                // });
            CreateMap<FeedRssEditDto, FeedRss>();
                // .ForMember(dest => dest.Icon, opt => {
                //     opt.MapFrom(src => File.ReadAllBytes(src.NewIconPath));
                // });;        
        }
    }
}