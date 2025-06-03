using System.ComponentModel.DataAnnotations;

namespace GrupoBIOS.Application.DTOs
{
    public class RoleDTO
    {
        [Required(ErrorMessage = "El rol es requerido")]
        public int IDRol { get; set; }
        public string? Rol { get; set; }
        public string? Descripcion { get; set; }
        public bool? Estado { get; set; }
        public DateTime? FechadeCreacion { get; set; }
        public string? CreadoPor { get; set; }

    }
}
