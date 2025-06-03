namespace GrupoBIOS.Domain.Entity
{
    public class Role
    {
        public int IDRol { get; set; }
        public string? Rol { get; set; }
        public string? Descripcion { get; set; }
        public bool? Estado { get; set; }
        public DateTime? FechadeCreacion { get; set; }
        public string? CreadoPor { get; set; }
    }
}
