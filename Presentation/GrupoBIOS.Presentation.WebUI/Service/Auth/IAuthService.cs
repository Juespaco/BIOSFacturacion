using GrupoBIOS.Application.DTOs;
using GrupoBIOS.Application.DTOs.Request.Auth;
using GrupoBIOS.Application.DTOs.Response.Auth;
using GrupoBIOS.Transversal.Common;

namespace GrupoBIOS.Presentation.WebUI.Service.Auth
{
    public interface IAuthService
    {
        Task<string> Register(UsuarioDTO register);
        Task<Response<LoginResponseDTO>> Login(LoginRequestDTO login);
        Task AuthProvider(string NombredeUsuario, string Token, string CompaniaIdSel, string CentroOperativo);
        Task<Response<IEnumerable<UsuarioDTO>>> GetListUsers();
        Task<Response<UsuarioDTO>> GetUserId(int IDUsuario);
        Task<Response<bool>> DesactivarUsuario(int IDUsuario);
        Task Logout();
        Task<string?> GetUserNameAsync();
        Task<string?> GetNameAsync();
        Task<string?> GetUserRoleAsync();
        Task<string?> UpdateUserAsync(UsuarioDTO register);
    }
}
