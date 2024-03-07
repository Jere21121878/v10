using AutoMapper;
using Back.Models.DTO;

namespace Back.Models.Profiles
{
    public class EmpresaProfile : Profile
    {
        public EmpresaProfile()
        {

            CreateMap<Empresa, EmpresaDTO>();
            CreateMap<EmpresaDTO, Empresa>();


        }
    }
}
