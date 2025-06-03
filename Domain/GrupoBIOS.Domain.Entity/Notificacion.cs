using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoBIOS.Domain.Entity
{
    public class Notificacion
    {
        public int IdNotificacion { get; set; }
        public int IdCompania { get; set; }
        public int Puerto { get; set; }
        public bool SSL { get; set; }
        public string Host { get; set; } = null!;
        public string EmailRemitente { get; set; } = null!;
        public string NombreRemitente { get; set; } = null!;
        public string UsuarioEmail { get; set; } = null!;
        public string ContrasenaEmail { get; set; } = null!;
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string CreadoPor { get; set; } = null!;

        public Compania? Compania { get; set; }
    }
}
