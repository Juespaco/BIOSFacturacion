using AutoMapper;
using GrupoBIOS.Application.DTOs;
using GrupoBIOS.Application.DTOs.Request.Auth;
using GrupoBIOS.Domain.Entity;
using GrupoBIOS.Domain.Entity.Request.Auth;
using GrupoBIOS.Domain.Entity.TuProyecto.Domain.Entities;

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

            CreateMap<Compania, CompaniaDTO>().ReverseMap();
            CreateMap<Notificacion, NotificacionDTO>().ReverseMap();
            CreateMap<Nivel, NivelDTO>().ReverseMap();
            CreateMap<CentroOperativo, CentroOperativoDTO>().ReverseMap();
            CreateMap<Pnc, PncDTO>().ReverseMap();
            CreateMap<Excepcion, ExcepcionDTO>().ReverseMap();

            CreateMap<ConfiguracionCompania, ConfiguracionCompaniaDTO>().ReverseMap();
        }
    }
}
