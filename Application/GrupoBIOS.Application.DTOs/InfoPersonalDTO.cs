using System.ComponentModel.DataAnnotations;

namespace GrupoBIOS.Application.DTOs
{
    public class InfoPersonalDTO
    {
        public int IDInfoPersonal { get; set; }
        public int IDUsuario { get; set; }
        [RegularExpression("^[1-6]$", ErrorMessage = "El tipo de documento es requerido.")]
        [Required]
        public int IDParametroTipoDocumento { get; set; }
        [Required(ErrorMessage = "El documento es requerido")]
        public string Documento { get; set; } = null!;
        [Required(ErrorMessage = "Los nombres son requeridos")]
        public string Nombres { get; set; } = null!;
        [Required(ErrorMessage = "Los apellidos son requeridos")]
        public string Apellidos { get; set; } = null!;
        
        [Required(ErrorMessage = "La dirección es requerida")] 
        public string Direccion { get; set; } = null!;
        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [RegularExpression(@"^[0-9]{7,15}$",
            ErrorMessage = "El teléfono debe contener solo números (7-15 dígitos)")]
        public string Telefono { get; set; } = null!;
        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "El formato del correo no es válido")]
        public string Correo { get; set; } = null!;
        [RegularExpression("^[1-6]$", ErrorMessage = "El genero es requerido.")]

        [Required(ErrorMessage = "El género es requerido")]
        public int IDParametroGenero { get; set; }
        public DateTime FechadeCreacion { get; set; }
        public string CreadoPor { get; set; } = null!;
    }
}
