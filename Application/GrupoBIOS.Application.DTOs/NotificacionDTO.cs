using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GrupoBIOS.Application.DTOs
{

    public class NotificacionDTO
    {
        public int IdNotificacion { get; set; }

        [Required(ErrorMessage = "El ID de la compañía es requerido")]
        public int IdCompania { get; set; }

        [Required(ErrorMessage = "El puerto es requerido")]
        public int Puerto { get; set; }

        [Required(ErrorMessage = "El campo SSL es requerido")]
        public bool SSL { get; set; }

        [Required(ErrorMessage = "El host es requerido")]
        [StringLength(255, ErrorMessage = "El host no debe exceder los 255 caracteres")]
        public string Host { get; set; } = null!;

        [Required(ErrorMessage = "El email remitente es requerido")]
        [EmailAddress(ErrorMessage = "El email remitente no tiene un formato válido")]
        [StringLength(255)]
        public string EmailRemitente { get; set; } = null!;

        [Required(ErrorMessage = "El nombre del remitente es requerido")]
        [StringLength(255)]
        public string NombreRemitente { get; set; } = null!;

        [Required(ErrorMessage = "El usuario del email es requerido")]
        [StringLength(255)]
        public string UsuarioEmail { get; set; } = null!;

        [Required(ErrorMessage = "La contraseña del email es requerida")]
        [StringLength(255)]
        public string ContrasenaEmail { get; set; } = null!;

        [Required(ErrorMessage = "El estado es requerido")]
        public bool Estado { get; set; }

        [Required(ErrorMessage = "El campo creado por es requerido")]
        public string CreadoPor { get; set; } = null!;
    }
}
