using AutoMapper;
using Back.Models.DTO;

namespace Back.Models.Profiles
{
    public class HerramientaProfile : Profile
    {
        public HerramientaProfile()
        {
            CreateMap<Herramienta, HerramientaDTO>();
            CreateMap<HerramientaDTO, Herramienta>();
        }
    }
}
