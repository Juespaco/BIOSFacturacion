using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrupoBIOS.Application.DTOs
{
    public class UsuarioDTO
    {
        public int IDUsuario { get; set; }

        [RegularExpression("^[1-6]$", ErrorMessage = "El rol es requerido.")]
        [Required]
        public int IDRol { get; set; }
        public string? NombreRol { get; set; }

        [RegularExpression("^[1-6]$", ErrorMessage = "La compañía es requerida.")]
        [Required]
        public int IDCompania { get; set; }

        [RegularExpression("^[1-6]$", ErrorMessage = "El centro operativo es requerido.")]
        [Required]
        public int IDCentroOperativo { get; set; }
        
        [Required(ErrorMessage = "La fecha de expiración del rol es requerida")]
        public DateTime? FechaExpiracionRol { get; set; }

        [Required(ErrorMessage = "El usuario es requerido")]
        public string NombredeUsuario { get; set; } = null!;
        
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres")]
        [DataType(DataType.Password)]
        public string Contrasena { get; set; } = null!;

        [Required(ErrorMessage = "Debe confirmar la contraseña")]
        [DataType(DataType.Password)]
        [Compare(nameof(Contrasena), ErrorMessage = "Las contraseñas no coinciden")]
        public string ConfirmarContrasena { get; set; } = null!;

        public bool Estado { get; set; }
        public DateTime FechadeCreacion { get; set; }
        public string CreadoPor { get; set; } = null!;
        public InfoPersonalDTO? InfoPersonal { get; set; }
        public bool IsUpdatePassword { get; set; }
    }
}
