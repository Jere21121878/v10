using AutoMapper;
using Back.Models.DTO;

namespace Back.Models.Profiles
{
    public class LegalProfile : Profile
    {

        public LegalProfile()
        {
            CreateMap<Legal, LegalDTO>();
            CreateMap<LegalDTO, Legal>();
        }


    }
}
