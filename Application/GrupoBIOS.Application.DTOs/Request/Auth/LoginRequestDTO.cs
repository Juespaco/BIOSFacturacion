using System.ComponentModel.DataAnnotations;

namespace GrupoBIOS.Application.DTOs.Request.Auth
{
    public class LoginRequestDTO
    {
        [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Debe tener entre 5 y 50 caracteres")]
        public string NombredeUsuario { get; set; } = string.Empty;
        [Required(ErrorMessage = "La contraseña de usuario es obligatorio")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Debe tener entre 5 y 50 caracteres")]
        public string Contrasena { get; set; } = string.Empty;        
        public int IDCompania { get; set; }
        public string IDCentroOperativo { get; set; } = string.Empty;
    }
}
