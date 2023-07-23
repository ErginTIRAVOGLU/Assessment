using Assessment.Kisiler.Api.Models.Dtos;
using AutoMapper;

namespace Assessment.Kisiler.Api.Models.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Kisi, KisiDto>().ReverseMap();
            CreateMap<Kisi, KisiListDto>().ReverseMap();
            CreateMap<Kisi, KisiListWIncDto>().ReverseMap();            
            CreateMap<IletisimBilgisi, IletisimBilgisiDto>().ReverseMap();
            CreateMap<IletisimBilgisi, IletisimBilgisiListDto>().ReverseMap();
        }
    }
}
