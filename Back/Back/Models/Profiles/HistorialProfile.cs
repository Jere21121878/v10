using AutoMapper;
using Back.Models.DTO;

namespace Back.Models.Profiles
{
    public class HistorialProfile : Profile
    {
        public HistorialProfile()
        {
            CreateMap<Historial, HistorialDTO>();
            CreateMap<HistorialDTO, Historial>();
        }
    }
}
