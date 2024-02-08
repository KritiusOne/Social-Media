using AutoMapper;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Enumeraciones;

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
            CreateMap<Security, SecurityDTO>().ReverseMap()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => (Roles)src.Role))
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
