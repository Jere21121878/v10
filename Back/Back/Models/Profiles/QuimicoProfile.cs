using AutoMapper;
using Back.Models.DTO;

namespace Back.Models.Profiles
{
    public class QuimicoProfile : Profile
    {
        public QuimicoProfile()
        {
            CreateMap<Quimico, QuimicoDTO>();
            CreateMap<QuimicoDTO, Quimico>();
        }

    }
}
