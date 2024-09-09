using AutoMapper;
using Crud.Entidades;
using CrudApi._01_Entidades.DTO;

namespace CrudApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateTimeDTO, Time>().ReverseMap();
        }
    }
}
