using GrupoBIOS.Domain.Entity.TuProyecto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoBIOS.Domain.Entity
{
    public class ConfiguracionCompania
    {
        public Compania? Compania { get; set; }
        public Notificacion? Notificacion { get; set; }
        public List<Nivel>? Niveles { get; set; }
        public List<CentroOperativo>? CentrosOperativos { get; set; }
        public List<Pnc>? Pncs { get; set; }
        public List<Excepcion>? Excepciones { get; set; }
    }

}
