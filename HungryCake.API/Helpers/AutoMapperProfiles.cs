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

            CreateMap<Category, CategoryListDto>()
                .ForMember(dest => dest.Parent, opt =>
                {
                    opt.MapFrom(c => c.Parent);
                });

            CreateMap<CategoryEditDto, Category>()
                .ForMember(dest => dest.ParentId, opt =>
                {
                    opt.MapFrom(c => c.Parent.Id);
                })
                .ForMember(dest => dest.Parent, opt =>
                {
                    opt.Ignore();
                });

            CreateMap<CategoryAddDto, Category>()
                .ForMember(dest => dest.ParentId, opt =>
                {
                    opt.MapFrom(c => c.Parent.Id);
                })
                .ForMember(dest => dest.Parent, opt =>
                {
                    opt.Ignore();
                });

            CreateMap<FeedRssAddDto, FeedRss>();
        }
    }
}