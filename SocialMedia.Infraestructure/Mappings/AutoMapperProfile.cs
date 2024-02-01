using AutoMapper;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;

namespace SocialMedia.Infraestructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Post, PostDTO>()
                .ForMember(x => x.PostId, y => y.MapFrom(src => src.Id));
            CreateMap<PostDTO, Post> ()
                .ForMember(x => x.Id, y => y.MapFrom(src => src.PostId));
        }
    }
}
