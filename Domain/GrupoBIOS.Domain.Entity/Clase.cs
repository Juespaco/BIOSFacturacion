namespace GrupoBIOS.Domain.Entity
{
    public class Clase
    {
        public int IDClase { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public bool Estado { get; set; }
        public DateTime FechadeCreacion { get; set; }
        public string CreadoPor { get; set; } = null!;
    }
}
