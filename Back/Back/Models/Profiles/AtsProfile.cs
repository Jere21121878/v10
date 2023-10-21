using AutoMapper;
using Back.Models.DTO;

namespace Back.Models.Profiles
{
    public class AtsProfile : Profile
    {
        public AtsProfile() {

            CreateMap<Ats, AtsDTO>();
            CreateMap<AtsDTO, Ats>();


        }
    }
}
