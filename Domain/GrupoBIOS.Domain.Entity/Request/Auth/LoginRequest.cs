namespace GrupoBIOS.Domain.Entity.Request.Auth
{
    public class LoginRequest
    {
        public string NombredeUsuario { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;
    }
}
