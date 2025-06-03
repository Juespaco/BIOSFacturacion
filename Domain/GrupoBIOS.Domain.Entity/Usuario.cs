namespace GrupoBIOS.Domain.Entity
{
    public class Usuario
    {        
        public int IDUsuario { get; set; }        
        public int IDRol { get; set; }        
        public string? NombreRol { get; set; }
        public int IDCompania { get; set; }        
        public int IDCentroOperativo { get; set; }
        public DateTime? FechaExpiracionRol { get; set; }
        public string NombredeUsuario { get; set; } = null!;
        public string Contrasena { get; set; } = null!;
        public bool Estado { get; set; }
        public DateTime FechadeCreacion { get; set; }
        public string CreadoPor { get; set; } = null!;
        public InfoPersonal? InfoPersonal { get; set; }
    }
}
