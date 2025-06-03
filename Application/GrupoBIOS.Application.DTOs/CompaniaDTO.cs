using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoBIOS.Application.DTOs
{
    public class CompaniaDTO
    {        
        public int IDCompania { get; set; }
        [Required(ErrorMessage = "El nombre de la companía es requerido")]
        public string? NombreCompania { get; set; } = null!;
        [Required(ErrorMessage = "El ID de Siesa es requerido")]
        public int? IDSiesa { get; set; }
        [Required(ErrorMessage = "El nombre de la base de datos es requerido")]
        public string? NombreBD { get; set; } = null!;
        [Required(ErrorMessage = "El nombre de la conexión es requerido")]
        public string? NombreConexionBD { get; set; } = null!;
        [Required(ErrorMessage = "la url del web service de siesa es requerido")]
        public string? UrlWebServiceSiesa { get; set; } = null!;
        [Required(ErrorMessage = "El usuario del webservice es requerido")]
        public string? UsuarioWebService { get; set; } = null!;
        [Required(ErrorMessage = "la clave del web service es requerida")]
        public string ClaveWebService { get; set; } = null!;
        public bool Estado { get; set; }        
        public DateTime? FechadeCreacion { get; set; }
        public string? CreadoPor { get; set; } = null!;        
    }
}
