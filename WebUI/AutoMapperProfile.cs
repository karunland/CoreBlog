using AutoMapper;
using EntityLayer.Dto;
using EntityLayer.Concrete;

namespace WebUI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegisterDto, Writer>()
                .ForMember(p => p.WriterAbout, opt => opt.MapFrom(src => ""));
            CreateMap<Writer, RegisterDto>();
            CreateMap<Comment, CommentDto>();
        }
    }
}
