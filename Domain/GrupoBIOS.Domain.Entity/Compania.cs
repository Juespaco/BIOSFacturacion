namespace GrupoBIOS.Domain.Entity
{
    public class Compania
    {
        public int IDCompania { get; set; }
        public string? NombreCompania { get; set; } = null!;
        public int? IDSiesa { get; set; }
        public string? NombreBD { get; set; } = null!;
        public string? NombreConexionBD { get; set; } = null!;
        public string? UrlWebServiceSiesa { get; set; } = null!;
        public string? UsuarioWebService { get; set; } = null!;
        public string ClaveWebService { get; set; } = null!;
        public bool Estado { get; set; }
        public DateTime FechadeCreacion { get; set; }
        public string CreadoPor { get; set; } = null!;
    }
}
