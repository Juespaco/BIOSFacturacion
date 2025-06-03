using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoBIOS.Domain.Entity
{
    public class Excepcion
    {
        public int IdExcepcion { get; set; }
        public int IdCompania { get; set; }
        public string? Planta { get; set; }
        public string? Nit { get; set; }
        public string? NombreCliente { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string CreadoPor { get; set; } = null!;

        public Compania? Compania { get; set; }
    }
}

