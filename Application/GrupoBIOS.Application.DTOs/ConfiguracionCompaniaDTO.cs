namespace GrupoBIOS.Application.DTOs
{
    public class ConfiguracionCompaniaDTO
    {
        public CompaniaDTO? Compania { get; set; } = new CompaniaDTO();
        public NotificacionDTO? Notificacion { get; set; } = new NotificacionDTO();
        public List<NivelDTO>? Niveles { get; set; } = new List<NivelDTO>();
        public List<CentroOperativoDTO>? CentrosOperativos { get; set; } = new List<CentroOperativoDTO>();
        public List<PncDTO>? Pncs { get; set; } = new List<PncDTO>();
        public List<ExcepcionDTO>? Excepciones { get; set; } = new List<ExcepcionDTO>();
    }
}
