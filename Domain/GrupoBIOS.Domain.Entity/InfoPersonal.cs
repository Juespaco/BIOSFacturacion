namespace GrupoBIOS.Domain.Entity
{
    public class InfoPersonal
    {    
        public int IDInfoPersonal { get; set; }        
        public int IDUsuario { get; set; }        
        public int IDParametroTipoDocumento { get; set; }        
        public string Documento { get; set; } = null!;
        public string Nombres { get; set; } = null!;        
        public string Apellidos { get; set; } = null!;        
        public string Direccion { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Correo { get; set; } = null!;        
        public int IDParametroGenero { get; set; }
        public DateTime FechadeCreacion { get; set; }
        public string CreadoPor { get; set; } = null!;        
    }
}
