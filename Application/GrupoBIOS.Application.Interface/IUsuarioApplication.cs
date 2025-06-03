using GrupoBIOS.Application.DTOs;
using GrupoBIOS.Application.DTOs.Request.Auth;
using GrupoBIOS.Transversal.Common;

namespace GrupoBIOS.Application.Interface
{
    public interface IUsuarioApplication : IApplication<UsuarioDTO>
    {
        Task<Response<UsuarioDTO>> GetLogin(LoginRequestDTO login);
        Task<Response<bool>> DesactivarUsuario(int IDUsuario);
    }
}
