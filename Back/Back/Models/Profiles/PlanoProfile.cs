using AutoMapper;
using Back.Models.DTO;

namespace Back.Models.Profiles
{
    public class PlanoProfile : Profile
    {

        public PlanoProfile()
        {
            CreateMap<Plano, PlanoDTO>();
            CreateMap<PlanoDTO, Plano>();
        }

    }
}
