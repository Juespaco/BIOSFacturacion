using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoBIOS.Application.DTOs
{
    public class ConfiguracionCompaniaDTO
    {
        public CompaniaDTO? Compania { get; set; }
        public List<NotificacionDTO>? Notificaciones { get; set; }
        public List<NivelDTO>? Niveles { get; set; }
        public List<CentroOperativoDTO>? CentrosOperativos { get; set; }
        public List<PncDTO>? Pncs { get; set; }
        public List<ExcepcionDTO>? Excepciones { get; set; }
    }
}
