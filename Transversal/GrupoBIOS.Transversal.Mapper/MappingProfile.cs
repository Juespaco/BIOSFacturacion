using AutoMapper;
using GrupoBIOS.Application.DTOs;
using GrupoBIOS.Application.DTOs.Request.Auth;
using GrupoBIOS.Domain.Entity;
using GrupoBIOS.Domain.Entity.Request.Auth;

namespace GrupoBIOS.Transversal.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<InfoPersonal, InfoPersonalDTO>().ReverseMap();
            CreateMap<Clase, ClaseDTO>().ReverseMap();
            CreateMap<Parametro, ParametroDTO>().ReverseMap();
            CreateMap<LoginRequest, LoginRequestDTO>().ReverseMap();
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<Compania, CompaniaDTO>().ReverseMap();
        }
    }
}
