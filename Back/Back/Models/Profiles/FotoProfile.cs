using AutoMapper;
using Back.Models.DTO;

namespace Back.Models.Profiles
{
    public class FotoProfile : Profile
    {
        public FotoProfile()
        {

            CreateMap<Foto, FotoDTO>();
            CreateMap<FotoDTO, Foto>();


        }
    }
}
