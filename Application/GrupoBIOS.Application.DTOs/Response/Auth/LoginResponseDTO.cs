namespace GrupoBIOS.Application.DTOs.Response.Auth
{
    public class LoginResponseDTO
    {
        public UsuarioDTO? Usuario { get; set; }
        public string? Token { get; set; }
        public DateTime? ExpiraEn { get; set; }
    }
}
