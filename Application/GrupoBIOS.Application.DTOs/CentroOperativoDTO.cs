using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoBIOS.Application.DTOs
{
    public class CentroOperativoDTO
    {
        public int IDCentroOperativo { get; set; }
        public int? IDCompania { get; set; }
        public string? IDSiesaCO { get; set; }
        public string? NombreCO { get; set; }
        public string? ReferenciadeCobro { get; set; }
        public string? PrefijodeFacturacion { get; set; }
        public string? MotivodeFacturacion { get; set; }
        public string? BodegaEspeciales { get; set; }
        public string? CorreoEnvioReporte { get; set; }
        public DateTime? FechaInicialCorte { get; set; }
        public int? CobroPNC { get; set; }
        public bool? Estado { get; set; }

        [StringLength(150)]
        public string CreadoPor { get; set; } = null!;
    }
}
