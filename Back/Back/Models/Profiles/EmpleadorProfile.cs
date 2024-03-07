using AutoMapper;
using Back.Models.DTO;

namespace Back.Models.Profiles
{
    public class EmpleadorProfile : Profile
    {
        public EmpleadorProfile()
        {

            CreateMap<Empleador, EmpleadorDTO>();
            CreateMap<EmpleadorDTO, Empleador>();


        }
    }
}
