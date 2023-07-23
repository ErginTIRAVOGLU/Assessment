using Assessment.Rapor.Api.Models.Dtos;
using AutoMapper;
 
namespace Assessment.Rapor.Api.Models.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Raporlar, RaporlarDto>().ReverseMap();
            CreateMap<RaporIcerik, RaporIcerikDto>().ReverseMap(); 
            CreateMap<RaporIcerik, Shared.RaporIcerik>().ReverseMap();
        }
    }
}
